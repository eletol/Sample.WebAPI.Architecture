using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace App.Services.Domain.Models
{
    public class Department
    {
        [Key]
        public int DId { get; set; }
        public string Name { get; set; }
     
        public virtual ICollection<Employee> Employees { get; set; }


    }
}