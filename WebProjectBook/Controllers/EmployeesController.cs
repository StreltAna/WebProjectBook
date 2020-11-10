using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProjectBook.Models;

namespace WebProjectBook.Controllers
{
   public class EmployeesController : Controller
   {
      private readonly EmployeesDbContext _dbEmployee;
      [BindProperty]
      public Employee Employee { get; set; }
      public EmployeesController(EmployeesDbContext dbEmployee)
      {
         _dbEmployee = dbEmployee;
      }

      public ActionResult Index()
      {
         return View();
      }

      public ActionResult Upsert(int? id)
      {
         Employee = new Employee();
         if (id == null)
         {
            //create
            return View(Employee);
         }
         //update
         Employee = _dbEmployee.Employees.FirstOrDefault(u => u.EmployeeId == id);
         if (Employee == null)
         {
            return NotFound();
         }
         return View(Employee);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public IActionResult Upsert()
      {
         if (ModelState.IsValid)
         {
            if (Employee.EmployeeId == 0)
            {
               //create
               _dbEmployee.Employees.Add(Employee);
            }
            else
            {  //Edit
               _dbEmployee.Employees.Update(Employee);
            }
            _dbEmployee.SaveChanges();
            return RedirectToAction("Index");
         }
         return View(Employee);
      }

      [HttpGet]
      public async Task<IActionResult> GetAll()
      {
         return Json(new { data = await _dbEmployee.Employees.ToListAsync() });
      }

      [HttpDelete]
      public async Task<IActionResult> Delete(int id)
      {
         var employeeFromDb = await _dbEmployee.Employees.FirstOrDefaultAsync(u => u.EmployeeId == id);
         if (employeeFromDb == null)
         {
            return Json(new { success = false, message = "Error while Deleting" });
         }
         _dbEmployee.Employees.Remove(employeeFromDb);
         await _dbEmployee.SaveChangesAsync();
         return Json(new { success = true, message = "Delete successful" });
      }
    
   }
}
