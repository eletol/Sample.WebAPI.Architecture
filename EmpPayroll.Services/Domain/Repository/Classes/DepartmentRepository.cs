using App.Services.Domain.Models;
using App.Services.Domain.Repository;
using App.Services.Domain.Repository.Interfaces;
using EmpPayroll.Services.Domain.Collections;

namespace EmpPayroll.Services.Domain.Repository.Classes
{
    public class DepartmentRepository:BaseRepository<Departments,Department>,IDepartmentRepository
    {
    }
}