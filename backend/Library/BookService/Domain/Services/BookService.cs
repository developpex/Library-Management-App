using BookService.Domain.Exceptions;
using BookService.Domain.Interfaces;
using BookService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.Domain.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        return await _bookRepository.GetBooksAsQuery().ToListAsync();
    }

    public async Task<Book> GetBookByTitle(string title)
    {
        var book = await _bookRepository.GetBooksAsQuery()
            .Where(book => book.Title == title)
            .FirstOrDefaultAsync();

        return book ?? throw new NotFoundException($"Book {title} not found");
    }
}