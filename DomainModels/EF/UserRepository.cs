using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;

namespace DomainModels.EF
{
    public class UserRepository : IUserRepository
    {
        private CalcContext context { get; set; }

        public UserRepository()
        {
            this.context = new CalcContext();
        }

        public void Create(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void Delete(User user)
        {
            context.Users
                .FirstOrDefault(u => u.Id == user.Id)
                .IsDeleted = true;
            context.SaveChanges();
        }

        public User Get(long id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {

            return context.Users.Where(u => u.IsDeleted == false).ToList();
        }

        public void Update(User user, Guid uid)
        {
            var dbuser = context.Users.FirstOrDefault(u => u.Uid == uid);
            if (user.FIO != null)
                dbuser.FIO = user.FIO;
            if (user.Login != null)
                dbuser.Login = user.Login;
            if (user.Password != null)
                dbuser.Password = user.Password;
            context.SaveChanges();
        }

        public bool Valid()
        {
            throw new NotImplementedException();
        }
    }
}
