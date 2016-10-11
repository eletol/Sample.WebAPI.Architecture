using System;
using System.Data.Entity.Migrations;
using App.Services.Domain.DBContext;
using App.Services.Domain.Models;
using Microsoft.AspNet.Identity;

namespace App.Services.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            var guid1 = Guid.NewGuid().ToString();
            var guid2 = Guid.NewGuid().ToString();
            var guid3 = Guid.NewGuid().ToString();
          

         
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("Password@123");
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "Steve@Steve.com",
                    Email = "Steve@Steve.com",
                    PasswordHash = password,
                    PhoneNumber = "08869879",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Id = guid2
                    
                });
            context.Departments.AddOrUpdate(
                    new Department() { DId = guid3, Name = "D1"}
                    );
            context.Employees.AddOrUpdate(
                     new Employee() {EId = Guid.NewGuid().ToString(), DId = guid3, Salary = 1000}
                     );
           
        }
  
     
    }
}