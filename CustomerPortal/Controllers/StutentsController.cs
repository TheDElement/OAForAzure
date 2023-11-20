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
    }
}
