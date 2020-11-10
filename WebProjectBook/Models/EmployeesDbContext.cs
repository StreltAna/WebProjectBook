using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjectBook.Models
{
   public class EmployeesDbContext : DbContext
   {
      public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options) : base(options)
      {
      }



      public DbSet<Employee> Employees { get; set; }
   }
   }



