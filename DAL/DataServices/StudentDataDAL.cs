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
        
        public string SaveStudentRecordDAL(Students FormData)
        {
            string result = string.Empty;

            try
            {
                using(IDbConnection dbConnection = _dapperOrmHelper.GetDapperContextHelper())
                {
                    string SqlQuery = "SELECT * FROM Students"; 
                    dbConnection.Execute(@"INSERT INTO Students(FirstName, LastName, Email)values(@FirstName, @LastName, @Email)",
                        new
                        {
                            FirstName = FormData.FirstName,
                            LastName = FormData.LastName,
                            Email = FormData.Email

                        },
                        commandType: CommandType.Text);

                    result = "Record Saved Successfully";

                }   
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return result;
        }
    }
}
