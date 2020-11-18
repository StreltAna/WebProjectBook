using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjectBook.Models
{
   public class Department
   {  [Key]
      public int Id { get; set; }
      [Required]
      public string Departmentname { get; set; }
      public string Departmentnumber { get; set; }
      public string Departmentcity { get; set; }
      public  ICollection<Employee> Employees { get; set; }
     
   }
}
