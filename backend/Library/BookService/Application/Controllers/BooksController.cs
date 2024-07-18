using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using BookService.Application.Contracts;
using BookService.Domain.Interfaces;

namespace BookService.Application.Controllers;

[Route("[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;

    public BooksController(IBookService bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
    }

    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _bookService.GetBooksAsync();
        var bookDtoList = books.Select(book => _mapper.Map(book));
        
        return Ok(bookDtoList);
    }

    [HttpGet("{title}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBookByTitle(string title)
    {
        var book = await _bookService.GetBookByTitle(title);
        var bookDto = _mapper.Map(book);
        
        return Ok(bookDto);
    }
}