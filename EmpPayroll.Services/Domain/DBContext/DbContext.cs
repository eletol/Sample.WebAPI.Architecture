using System.Data.Entity;
using App.Services.Domain.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace App.Services.Domain.DBContext
{

    public class DbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public DbContext()
            : base("DefaultConnection", false)
        {
            this.Configuration.ProxyCreationEnabled = false;

        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public static DbContext Create()
        {
            return new DbContext();
        }

      
    }
}