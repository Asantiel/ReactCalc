using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    [Table("OperationResult")]
    public class OperationResult
    {
        public long Id { get; set; }

        public Guid Uid { get; set; }

        public long AuthorId { get; set; }

        public virtual User Author { get; set; }

        public long OperationId { get; set; }

        public virtual Operation Operation { get; set; }

        public string InputData { get; set; }

        public double Result { get; set; }

        public int ExecutionTime { get; set; }

        public DateTime ExecutionDate { get; set; }
    }
}
