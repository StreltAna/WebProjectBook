using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProjectBook.Data;
using WebProjectBook.Models;

namespace WebProjectBook.Controllers
{
   public class EmployeesController : Controller
   {
      private readonly EmployeesDbContext _context;

      public EmployeesController(EmployeesDbContext context)
      {
         _context = context;
      }

      // GET: Employees
      public async Task<IActionResult> Index()
      {
         var employeesDbContext = _context.Employees.Include(e => e.Department);
         return View(await employeesDbContext.ToListAsync());
      }

      // GET: Employees/Details/5
      public async Task<IActionResult> Details(int? id)
      {
         if (id == null)
         {
            return NotFound();
         }

         var employee = await _context.Employees
             .Include(e => e.Department)
             .FirstOrDefaultAsync(m => m.Id == id);
         if (employee == null)
         {
            return NotFound();
         }

         return View(employee);
      }

      // GET: Employees/Create
      //ToDo: Hinter Department Liste einen "Bitte auswählen" Eintrag hinzufügen
      public IActionResult Create()
      {
         //ViewData["Id"] = new SelectList(_context.Department, "Id", "Departmentname");
         var model = new EmployeeViewModel()
         {
            Departments = new SelectList(_context.Department, "Id", "Departmentname")
         };
         return View(model);
      }
      
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create(EmployeeViewModel model)
      {
         if (ModelState.IsValid)
         {
            model.Department = await _context.Department.FirstOrDefaultAsync(d => d.Id == model.DepartmentId);
            _context.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
         }

         model.Departments = new SelectList(_context.Department, "Id", "Departmentname");
         return View(model);
      }

      // GET: Employees/Edit/5
      public async Task <IActionResult> Edit(int? id)
      {
         if (id == null)
         {
            return NotFound();
         }
         var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);

         var model = new EmployeeViewModel(employee)
         {
            
            Departments = new SelectList(_context.Department, "Id", "Departmentname")
         };
         if (model == null)
         {
            return NotFound();
         }
        
         return View(model);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(int id, EmployeeViewModel model)
      {
         if (id != model.Id)
         {
            return NotFound();
         }

         if (ModelState.IsValid)
         {

            try
            {
               _context.Update(model);
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               if (!EmployeeExists(model.Id))
               {
                  return NotFound();
               }
               else
               {
                  throw;
               }
            }
            return RedirectToAction(nameof(Index));
         }
         return View(model);
      }

      // GET: Employees/Delete/5
      public async Task<IActionResult> Delete(int? id)
      {
         if (id == null)
         {
            return NotFound();
         }

         var employee = await _context.Employees
        .FirstOrDefaultAsync(m => m.Id == id);
         if (employee == null)
         {
            return NotFound();
         }

         return View(employee);
      }

      // POST: Employees/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id)
      {
         var employee = await _context.Employees.FindAsync(id);
         _context.Employees.Remove(employee);
         await _context.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
      }

      private bool EmployeeExists(int id)
      {
         return _context.Employees.Any(e => e.Id == id);
      }
   }
}
