using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using App.Services.Domain.Models;

namespace App.Services.Domain.Models
{
    public class Employee
    {
        [Key]
        public string EId { get; set; }
       
        public string DId { get; set; }
        public virtual Department Department { get; set; }
        [Required]
        public double Salary { get; set; }
        public int? ManagerID { get; set; }
        public Employee Manager { get; set; }
    }
}