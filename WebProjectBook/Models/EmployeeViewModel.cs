using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjectBook.Models
{

   public class EmployeeViewModel : Employee
   {
      public EmployeeViewModel() { }
      
      public EmployeeViewModel(Employee employee)
      {
         Firstname = employee.Firstname;
         Lastname = employee.Lastname;
         Gender = employee.Gender;
         Id = employee.Id;
         Department = employee.Department;
      }
      public int DepartmentId { get; set; }
      public SelectList Departments { get; set; }
   }
}
