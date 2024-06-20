using BookService.Domain.Models;

namespace BookService.Domain.Interfaces;

public interface IBookService
{
    Task<IEnumerable<Book>> GetBooksAsync();
}