using App.Services.Domain.DBContext;
using App.Services.Domain.Models;
using DAL.SDK.common;

namespace App.Services.Domain.Collections
{
    public class Employees: BusinessCollection<Employee, DbContext>
    {
     
    }
}