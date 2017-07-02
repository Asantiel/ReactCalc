using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;
using System.Data.SqlClient;

namespace DomainModels.Repository
{
    public class OperationResultRepository : IOperationResultRepository
    {
        private IUserRepository User { get; set; }
        private IOperationRepository Operation { get; set; }

        public OperationResultRepository()
        {
            User = new UserRepository();
            Operation = new OperationRepository();
        }

        public OperationResult Get(long id)
        {
            using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Anuo\ReactCalc\DomainModels\App_Data\reactcalcdb.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("SELECT Id, Author, Operation, InputData, Result , ExecutionTime , ExecutionDate FROM OperationResult WHERE Id=" + id + ";", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var author = User.Get(reader.GetInt64(1));
                        var operation = Operation.Get(reader.GetInt64(2));
                        var inputdata = reader.GetString(3);
                        var result = reader.GetDouble(4);
                        var exectime = reader.GetInt32(5);
                        var execdate = reader.GetDateTime(6);

                        return new OperationResult()
                        {
                            Id = id,
                            Author = author,
                            Operation = operation,
                            InputData = inputdata,
                            Result = result,
                            ExecutionTime = exectime,
                            ExecutionDate = execdate
                        };
                    }
                }
                reader.Close();
                return null;
            }
        }

        public IEnumerable<OperationResult> GetAll()
        {
            using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Anuo\ReactCalc\DomainModels\App_Data\reactcalcdb.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("SELECT Id, Author, Operation, InputData, Result , ExecutionTime , ExecutionDate FROM OperationResult;", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var author = User.Get(reader.GetInt64(1));
                        var operation = Operation.Get(reader.GetInt64(2));
                        var inputdata = reader.GetString(3);
                        var result = reader.GetDouble(4);
                        var exectime = reader.GetInt32(5);
                        var execdate = reader.GetDateTime(6);

                        yield return new OperationResult()
                        {
                            Id = id,
                            Author = author,
                            Operation = operation,
                            InputData = inputdata,
                            Result = result,
                            ExecutionTime = exectime,
                            ExecutionDate = execdate
                        };
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }
        }
    }
}
