using App.Services.Domain.Collections;
using App.Services.Domain.Models;
using App.Services.Domain.Repository.Interfaces;

namespace App.Services.Domain.Repository
{
    public class EmployeeRepository :BaseRepository<Employees,Employee>,IEmployeeRepository
    {
    }
}