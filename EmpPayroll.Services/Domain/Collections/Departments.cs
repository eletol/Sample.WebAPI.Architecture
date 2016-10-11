using App.Services.Domain.DBContext;
using App.Services.Domain.Models;
using DAL.SDK.common;

namespace EmpPayroll.Services.Domain.Collections
{
    public class Departments: BusinessCollection<Department, DbContext>
    {
    }
}