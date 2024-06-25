using BookService.Application.Controllers;
using BookService.Domain.Interfaces;
using BookService.Domain.Models;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Tests.Controller
{
    public class BooksControllerTests
    {
        private readonly IBookService _bookService = A.Fake<IBookService>();

        [Fact]
        public async void BooksController_GetBooks_ShouldReturnOK()
        {
            //Arrange
            var controller = new BooksController(_bookService);

            //Act
            var result = await controller.GetBooks();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}
