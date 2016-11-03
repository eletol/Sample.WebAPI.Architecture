using App.Services.Domain.DBContext;
using App.Services.Domain.Models;
using App.Services.Domain.Repository;
using App.Services.Domain.Repository.Interfaces;
using EmpPayroll.Services.Domain.Collections;

namespace EmpPayroll.Services.Domain.Repository.Classes
{
    public class DepartmentRepository:BaseRepository<Departments,Department>,IDepartmentRepository
    {
        public IDbContext Context { get; set; }
        public DepartmentRepository(DbContext context) : base(context)
        {
            Context= context;
        }
    }
}