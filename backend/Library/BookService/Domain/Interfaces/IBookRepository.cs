using BookService.Domain.Models;

namespace BookService.Domain.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetBooksAsync();
}