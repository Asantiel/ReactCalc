using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Repository
{
    public interface IUserRepository
    {
        bool Valid();

        User Create();

        User Get(long id);

        void Update(User user);

        void Delete(User user);

        IEnumerable<User> GetAll();
    }
}
