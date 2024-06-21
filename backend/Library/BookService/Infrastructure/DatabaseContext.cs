using BookService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.Infrastructure
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {}

        public DbSet<Book> Books => Set<Book>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(book =>
            {
                book.ToTable("Books");
                book.HasKey(b => b.Id);
            });
        }
    }
}
