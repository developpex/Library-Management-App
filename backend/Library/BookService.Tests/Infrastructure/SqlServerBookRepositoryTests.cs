using BookService.Domain.Models;
using BookService.Infrastructure;
using BookService.Infrastructure.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BookService.Tests.Infrastructure
{
    public class SqlServerBookRepositoryTests
    {
        private async Task<DatabaseContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new DatabaseContext(options);
            await databaseContext.Database.EnsureCreatedAsync();
            
            if (await databaseContext.Books.CountAsync().ConfigureAwait(false) > 0) return databaseContext;
            
            for (var i = 0; i < 10; i++)
            {
                databaseContext.Books.Add(
                    new Book()
                    {
                        Id = Guid.NewGuid(),
                        Title = $"Title {i}",
                        Authors = $"Authors {i}",
                        Month = "Moth",
                        Year = 1991,
                        Price = "0.99"
                    });
                await databaseContext.SaveChangesAsync();
            }

            return databaseContext;
        }

        [Fact]
        public async void SqlServerBookRepository_GetBooksAsQuery_ShouldReturnIQueryableOfBooks()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();

            //Act
            var bookRepository = new SqlServerBookRepository(dbContext);
            var result = bookRepository.GetBooksAsQuery();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(EntityQueryable<Book>));
        }
    }
}
