using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Repository
{
    public interface IEntityRepository<T>
    {
        T Create();

        void Update(T entity);

        T Get(long id);

        void Delete(T user);

        IEnumerable<T> GetAll();

        IQueryable<T> GetAll(Func<T, bool> condition);
    }
}
