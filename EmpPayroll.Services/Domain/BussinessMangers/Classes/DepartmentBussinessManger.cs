using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using App.Services.Domain.BussinessMangers.Interfaces;
using App.Services.Domain.Models;
using App.Services.Domain.Repository.Interfaces;
using App.Services.Domain.UnitOfWork;
using EmpPayroll.Services.Domain.Repository.Classes;


namespace App.Services.Domain.BussinessMangers.Classes
{
    public class DepartmentBussinessManger 
        <TRepository>: BaseBussinessManger<Department, TRepository>, IDepartmentBussinessManger where TRepository :IDepartmentRepository
    {
    

        public DepartmentBussinessManger(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
              
        }

        public override IQueryable<Department> Get(Expression<Func<Department, bool>> filter = null, Func<IQueryable<Department>, IOrderedQueryable<Department>> orderBy = null, string includeProperties = "")
        {
            return base.Get(filter, orderBy, "Employees");
        }

    }
}