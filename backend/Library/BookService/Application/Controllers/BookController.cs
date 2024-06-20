using BookService.Application.Models.OutgoingDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using BookService.Domain.Interfaces;
using BookService.Domain.Models;

namespace BookService.Application.Controllers;

[Route("[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;


    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Books_OutgoingDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<Books_OutgoingDto>> GetBooks()
    {
        var books = await _bookService.GetBooksAsync();
        return books.Select(ConvertDomainToOutgoingDto).ToArray();
    }

    private Books_OutgoingDto ConvertDomainToOutgoingDto(Book book)
    {
        return new Books_OutgoingDto
        {
            Id = book.Id,
            Title = book.Title,
            Authors = book.Authors,
            Category = book.Category,
            Description = book.Description,
            Publisher = book.Publisher,
            Month = book.Month,
            Year = book.Year,
            Price = book.Price
        };
    }
}