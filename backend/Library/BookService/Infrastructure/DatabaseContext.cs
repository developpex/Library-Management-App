using BookService.Domain.Models;
using BookService.Infrastructure.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BookService.Infrastructure
{
    public class DatabaseContext: DbContext
    {
        protected readonly IConfiguration Configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("Library"));
        }

        public DbSet<DbBook> Books => Set<DbBook>();
    }
}
