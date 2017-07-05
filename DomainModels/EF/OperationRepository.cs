using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;

namespace DomainModels.EF
{
    public class OperationRepository : IOperationRepository
    {
        private CalcContext context { get; set; }

        public OperationRepository()
        {
            this.context = new CalcContext();
        }

        public Operation Create()
        {
            throw new NotImplementedException();
        }

        public void Delete(Operation user)
        {
            throw new NotImplementedException();
        }

        public Operation Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operation> GetAll()
        {
            return context.Operations.ToList();
        }

        public void Update(Operation entity)
        {
            throw new NotImplementedException();
        }

        public Operation GetByName(string name)
        {
            return context.Operations.FirstOrDefault(o => o.Name == name);
        }

        public IQueryable<Operation> GetAll(Func<Operation, bool> condition)
        {
            throw new NotImplementedException();
        }
    }
}
