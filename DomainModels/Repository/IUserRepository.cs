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

        void Create(User user);

        User Get(long id);

        void Update(User user, Guid uid);

        void Delete(User user);

        IEnumerable<User> GetAll();
    }
}
