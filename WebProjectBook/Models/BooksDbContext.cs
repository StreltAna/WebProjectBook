using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjectBook.Models
{
   public class BooksDbContext : DbContext
   {
      public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
      {

      }

      public DbSet<Book> Books { get; set; }
   }
}
