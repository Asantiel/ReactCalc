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

        public User Create()
        {
            throw new NotImplementedException();
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

        public void Update(User user)
        {
            context.Entry(user).State = user.Id == 0
                ? System.Data.Entity.EntityState.Added
                : System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public bool IsValid(string name, string pass)
        {
            return context.Users.Count(i => i.Login == name && !i.IsDeleted && i.Password == pass) == 1;
        }

        public User GetByName(string name)
        {
            return context.Users.FirstOrDefault(u=>!u.IsDeleted && u.Login == name);
        }

        public void CreateUser(User user)
        {
            user.Uid = Guid.NewGuid();
            context.Entry(user).State = System.Data.Entity.EntityState.Added;
            context.SaveChanges();
        }

        public IQueryable<User> GetAll(Func<User, bool> condition)
        {
            throw new NotImplementedException();
        }
    }
}
