using BookService.Domain.Interfaces;
using BookService.Domain.Models;

namespace BookService.Domain.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IEnumerable<Book>> GetBooksAsync() => await _bookRepository.GetBooksAsync();

}