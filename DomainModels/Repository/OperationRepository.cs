using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;
using System.Data.SqlClient;

namespace DomainModels.Repository
{
    public class OperationRepository : IOperationRepository
    {
        Operation IOperationRepository.Get(long id)
        {
            using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Anuo\ReactCalc\DomainModels\App_Data\reactcalcdb.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("SELECT Id, Name, FullName FROM Operation WHERE Id=" + id + ";", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var name = reader.GetString(1);
                        var fullname = reader.GetString(2);

                        return new Operation()
                        {
                            Id = id,
                            Name = name,
                            FullName = fullname
                        };
                    }
                }
                reader.Close();
                return null;
            }
        }

        IEnumerable<Operation> IOperationRepository.GetAll()
        {
            using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Anuo\ReactCalc\DomainModels\App_Data\reactcalcdb.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("SELECT Id, Name, FullName FROM Operation;", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var name = reader.GetString(1);
                        var fullname = reader.GetString(2);

                        yield return new Operation()
                        {
                            Id = id,
                            Name = name,
                            FullName = fullname
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
