using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    public class UserFavoriteResult
    {
        public long Id { get; set; }

        public User Users { get; set; }

        public OperationResult Result { get; set; }
    }
}
