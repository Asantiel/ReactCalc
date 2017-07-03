using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.EF
{
    [Table("Users")]
    public class CalcContext : DbContext
    {

        public CalcContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Anuo\ReactCalc\DomainModels\App_Data\reactcalcdb.mdf;Integrated Security=True")
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Operation> Operations { get; set; }

        public DbSet<OperationResult> OperationResult { get; set; }

        public DbSet<UserFavoriteResult> UserFavoriteResult { get; set; }
    }
}
