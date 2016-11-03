using System;
using App.Services.Domain.BussinessMangers.Interfaces;
using App.Services.Domain.Models;
using App.Services.Domain.Repository.Interfaces;
using App.Services.Domain.UnitOfWork;


namespace App.Services.Domain.BussinessMangers.Classes
{
    public class EmployeeBussinessManger<TRepository> :
        BaseBussinessManger<Employee, TRepository>,IEmployeeBussinessManger
        where TRepository : IEmployeeRepository
    {
        private readonly IEmployeeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeBussinessManger(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
           
        }
      
     
    }
}