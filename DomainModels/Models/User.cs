using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    [Table("Users")]
    public class User
    {
        public User()
        {
            OperationResults = new List<OperationResult>();
            UserFavoriteResult = new List<UserFavoriteResult>();
        }

        public long Id { get; set; }

        public Guid Uid { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string FIO { get; set; }

        public virtual ICollection<OperationResult> OperationResults
        {
            get; set;
        }

        public virtual ICollection<UserFavoriteResult> UserFavoriteResult
        {
            get; set;
        }
    }
}
