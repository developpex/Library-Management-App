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
}