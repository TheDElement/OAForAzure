using BOL.DataBaseEntities;
using DAL.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LogicServices
{
    public class StudentsLogic : IStudentsLogic
    {
        private readonly IStudentDataDAL _studentDataDAL; // Dependency Injection
        public StudentsLogic(IStudentDataDAL studentDataDAL) // Dependency Injection via Constructor
        {
            _studentDataDAL = studentDataDAL;
        }
        public List<Students> GetStudentsListLogic()
        {
            List<Students> studentsList = new List<Students>();
            studentsList = _studentDataDAL.GetStudentsListDAL();
            return studentsList;
        }

        public string SaveStudentRecordLogic(Students FormData)
        {
            string result = string.Empty;
            if(String.IsNullOrEmpty(FormData.FirstName) || String.IsNullOrEmpty(FormData.LastName) || String.IsNullOrEmpty(FormData.Email))
            {
                return result = "Please give all the information";
            }

            result = _studentDataDAL.SaveStudentRecordDAL(FormData);
            
            if(result == "Record Saved Successfully")
            {
                return result;
            }
            else
            {
                return result = "Something went wrong";
            }

        }
    }
}
