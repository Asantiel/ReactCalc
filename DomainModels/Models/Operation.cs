using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    [Table("Operation")]
    public class Operation
    {
        public long Id { get; set; }

        public Guid Uid { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public virtual ICollection<OperationResult> OperationResults { get; set; }
    }
}
