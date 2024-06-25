using BookService.Domain.Interfaces;
using BookService.Domain.Models;

namespace BookService.Infrastructure.Repositories;

public class SqlServerBookRepository : IBookRepository
{
    private readonly DatabaseContext _databaseContext;

    public SqlServerBookRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public IQueryable<Book> GetBooksAsQuery()
    {
         return  _databaseContext.Books.Take(100);
    }
}