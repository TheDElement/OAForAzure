using BOL.DataBaseEntities;
using DAL.DataContext;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataServices
{
    public class StudentDataDAL : IStudentDataDAL
    {
        private readonly IDapperOrmHelper _dapperOrmHelper;

        public StudentDataDAL(IDapperOrmHelper dapperOrmHelper)
        {
            _dapperOrmHelper = dapperOrmHelper;
        }

        public List<Students> GetStudentsListDAL()
        {
            List<Students> studentsList = new List<Students>();

            try
            {
                using(IDbConnection dbConnection = _dapperOrmHelper.GetDapperContextHelper())
                {
                    string SqlQuery = "SELECT * FROM Students"; 
                    studentsList = dbConnection.Query<Students>(SqlQuery, commandType: CommandType.Text).ToList();

                }   
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return studentsList;
        }
    }
}
