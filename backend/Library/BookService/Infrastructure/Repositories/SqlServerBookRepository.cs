using BookService.Domain.Interfaces;
using BookService.Domain.Models;
using BookService.Infrastructure.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BookService.Infrastructure.Repositories;

public class SqlServerBookRepository : IBookRepository
{
    private readonly DatabaseContext _databaseContext;

    public SqlServerBookRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        var books = await _databaseContext.Books.Take(10).ToListAsync();
        return books.Select(ConvertDbToDomain).ToArray();
    }

    private Book ConvertDbToDomain(DbBook book)
    {
        return new Book
        {
            Id = book.Id.ToString(),
            Title = book.Title,
            Authors = book.Authors,
            Publisher = book.Publisher,
            Category = book.Category,
            Description = book.Description,
            Month = book.Month,
            Year = book.Year,
            Price = float.Parse(book.Price)
        };
    }
}