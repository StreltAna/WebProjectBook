using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProjectBook.Data;
using WebProjectBook.Models;

namespace WebProjectBook.Controllers
{
   public class BooksController : Controller
   {
      private readonly BooksDbContext _db;
      [BindProperty]
      public Book Book { get; set; }
      public BooksController(BooksDbContext db)
      {
         _db = db;
      }
      public ActionResult Index()
      {
         return View();
      }

      public ActionResult Upsert(int? id)
      {
         Book = new Book();
         if (id == null)
         {
            //create
            return View(Book);
         }

         //update
         Book = _db.Books.FirstOrDefault(u => u.Id == id);
         if (Book == null)
         {
            return NotFound();
         }

         return View(Book);
      }


      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Upsert()
      {
         if (ModelState.IsValid)
         {
            if (Book.Id == 0)
            {
               _db.Books.Add(Book);
            }
            else
            {
               _db.Books.Update(Book);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
         }
         return View(Book);
      }

      #region API Calls
      [HttpGet]
      public async Task<IActionResult> GetAll()
      {
         return Json(new { data = await _db.Books.ToListAsync() });
      }


      #endregion API Calls

     // GET: BooksController/Details/5
      public ActionResult Details(int id)
      {
         return View();
      }

      // GET: BooksController/Create
      public ActionResult Create()
      {
         return View();
      }

      // POST: BooksController/Create
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Create(IFormCollection collection)
      {
         try
         {
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }

      // GET: BooksController/Edit/5
      public ActionResult Edit(int id)
      {
         return View();
      }

      // POST: BooksController/Edit/5
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Edit(int id, IFormCollection collection)
      {
         try
         {
            if (ModelState.IsValid) { }//Mit dem Befehl wird geprüft ob alle Felder ausgefüllt sind
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }

      //GET: BooksController/Delete/5

      [HttpDelete]
      public async Task<IActionResult> Delete(int id)
      {
         var bookFromDb = await _db.Books.FirstOrDefaultAsync(u => u.Id == id);
         if (bookFromDb == null)
         {
            return Json(new { success = false, message = "Error while Deleting" });
         }
         _db.Books.Remove(bookFromDb);
         await _db.SaveChangesAsync();
         return Json(new { success = true, message = "Delete successful" });
      }

      // POST: BooksController/Delete/5
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Delete(int id, IFormCollection collection)
      {
         try
         {
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }
   }
}

