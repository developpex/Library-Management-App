using BookService.Domain.Models;

namespace BookService.Domain.Interfaces;

public interface IBookRepository
{
    IQueryable<Book> GetBooksAsQuery();
}