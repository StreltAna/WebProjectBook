using Microsoft.EntityFrameworkCore;


namespace WebProjectBook.Data
{
   public class BooksDbContext : DbContext
   {
      public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
      {

      }

      public DbSet<Models.Book> Books { get; set; }
   }
}
