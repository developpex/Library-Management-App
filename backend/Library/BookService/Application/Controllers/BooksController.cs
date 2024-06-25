using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using BookService.Domain.Interfaces;

namespace BookService.Application.Controllers;

[Route("[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;


    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetBooks()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
       
        return Ok(await _bookService.GetBooksAsync());
    }
}