using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjectBook.Models
{
   public class EmployeeViewModel : Employee
   {
      public int DepartmentId { get; set; }
      public SelectList Departments { get; set; }
   }
}
