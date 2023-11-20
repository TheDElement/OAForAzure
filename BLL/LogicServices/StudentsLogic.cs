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
    }
}
