using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;
using System.Data.SqlClient;

namespace DomainModels.Repository
{
    public class UserRepository : IUserRepository
    {
        public User Create()
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public User Get(long ID)
        {
            using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Anuo\ReactCalc\DomainModels\App_Data\reactcalcdb.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("SELECT Id, FIO, Login FROM Users WHERE Id="+ID+";", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var fio = reader.GetString(1);
                        var login = reader.GetString(2);

                        return new User()
                        {
                            Id = id,
                            FIO = fio,
                            Login = login
                        };
                    }
                }
                reader.Close();
                return null;
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Anuo\ReactCalc\DomainModels\App_Data\reactcalcdb.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("SELECT Id, FIO, Login FROM Users;",connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var fio = reader.GetString(1);
                        var login = reader.GetString(2);

                        yield return new User()
                        {
                            Id = id,
                            FIO = fio,
                            Login = login
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

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public bool Valid()
        {
            throw new NotImplementedException();
        }
    }
}
