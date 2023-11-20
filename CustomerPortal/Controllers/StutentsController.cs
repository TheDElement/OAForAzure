using BLL.LogicServices;
using BOL.CommonEntities;
using BOL.DataBaseEntities;
using Microsoft.AspNetCore.Mvc;

namespace CustomerPortal.Controllers
{
    public class StutentsController : Controller
    {
        private readonly IStudentsLogic _studentsLogic;
        public StutentsController(IStudentsLogic studentsLogic)
        {
            _studentsLogic = studentsLogic;
        }
        [HttpGet]
        public IActionResult StudentList()
        
        {
            // -- Main  Model

            StudentModule studentModule = new StudentModule();
            //List<Students> result = new List<Students>();
            studentModule.studentsList = _studentsLogic.GetStudentsListLogic();

            //-- GEt Students List


            return View(studentModule);
        }

        [HttpGet]
        public IActionResult CreateStudent()
        {
            

            return View();
        }

        [HttpPost]
        public IActionResult CreateStudentPost(Students FormData)
        {
            
               string result = _studentsLogic.SaveStudentRecordLogic(FormData);

                if(result == "Record Saved Successfully")
                {
                    return RedirectToAction("StudentList", "Stutents");
                }
                else
                {
                    TempData["Error"] = result;
                    return RedirectToAction("CreateStudent", "Stutents");
                }
        }
    }
}
