using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;

namespace DomainModels.Repository
{
    public interface IOperationResultRepository
    {
        OperationResult Get(long id);

        IEnumerable<OperationResult> GetAll();

        
    }
}
