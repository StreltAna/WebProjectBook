using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProjectBook.Models;

namespace WebProjectBook.Data
{
   public class EmployeesDbContext : DbContext
   {
      public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options) : base(options)
      {
      }


    
      public DbSet<Employee> Employees { get; set; }


    
      public DbSet<Department> Department { get; set; }
   }
   }



