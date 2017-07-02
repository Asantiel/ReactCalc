using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;
using System.Data.SqlClient;
using DomainModels.Repository;

namespace DomainModels.Repository
{
    public class UserFavoriteResultRepository : IUserFavoriteResultRepository

    {
        private IUserRepository Users { get; set; }
        private IOperationResultRepository OperationResult { get; set; }

        public UserFavoriteResultRepository()
        {
            Users = new UserRepository();
            OperationResult = new OperationResultRepository();
        }

        public UserFavoriteResultRepository Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserFavoriteResult> GetAll()
        {
            using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Anuo\ReactCalc\DomainModels\App_Data\reactcalcdb.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("SELECT Id, Users, Result FROM UserFavoriteResult;", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var user = Users.Get(reader.GetInt64(1));
                        var result = OperationResult.Get(reader.GetInt64(2));

                        yield return new UserFavoriteResult()
                        {
                            Id = id,
                            Users = user,
                            Result = result
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
