using BookService.Application.Controllers;
using BookService.Domain.Interfaces;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Tests.Application;

public class BooksControllerTests
{
    private readonly IBookService _bookService = A.Fake<IBookService>();
    private readonly IMapper _mapper = A.Fake<IMapper>();

    
    [Fact]
    public async void BooksController_GetBooks_ShouldReturnOK()
    {
        //Arrange
        var controller = new BooksController(_bookService, _mapper);

        //Act
        var result = await controller.GetBooks();

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));
    }
}