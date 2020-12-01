using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjectBook.Models
{
   public class Employee
   {
    
      [Key]
      public int Id {get; set;}

      [Required]
      public string Firstname { get; set; }
      public string Lastname { get; set; }
      public string Gender { get; set; }

      public int? DepartmentId { get; set; }
      public Department Department { get; set; }
      
   }
}
