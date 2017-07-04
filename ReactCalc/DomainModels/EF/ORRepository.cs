using DomainModels.Models;
using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.EF
{
    public class ORRepository : IORRepository
    {
        private CalcContext context { get; set; }

        public ORRepository()
        {
            this.context = new CalcContext();
        }

        public OperationResult Create(OperationResult result)
        {
            return new OperationResult
            {
                Uid = Guid.NewGuid()
            };
        }

        public void Delete(OperationResult result)
        {
            context.Entry(result).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }

        public OperationResult Get(long id)
        {
            return context.OperationResult.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<OperationResult> GetAll()
        {

            return context.OperationResult.ToList();
        }

        public void Update(OperationResult result)
        {
            context.Entry(result).State = result.Id == 0
                ? System.Data.Entity.EntityState.Added
                : System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public double GetOldResult(long operationID, string inputData)
        {
            var rec = context.OperationResult
                .FirstOrDefault(u => u.OperationId == operationID && u.InputData == inputData);
                return rec != null ? rec.Result : double.NaN;
        }
    }
}
