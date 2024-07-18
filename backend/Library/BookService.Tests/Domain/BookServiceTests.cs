using BookService.Domain.Interfaces;
using BookService.Domain.Models;
using FakeItEasy;
using FluentAssertions;

namespace BookService.Tests.Domain;

public class BookServiceTests
{
    private readonly IBookRepository _bookRepository = A.Fake<IBookRepository>();

    [Fact (Skip = "The source 'IQueryable' doesn't implement error")]
    public async void BookService_GetBooksAsync_ShouldReturnIEnumerableOfBooks()
    {
        //Arrange
        var books = new List<Book>
        {
            new Book
            {
                Id = Guid.NewGuid(), Title = "Book 1", Authors = "Author 1", Month = "January", Year = 2000,
                Price = "10.00"
            },
            new Book
            {
                Id = Guid.NewGuid(), Title = "Book 2", Authors = "Author 2", Month = "February", Year = 2001,
                Price = "15.00"
            }
        }.AsQueryable();

        A.CallTo(() => _bookRepository.GetBooksAsQuery()).Returns(books).As<IQueryable<Book>>();

        var bookService = new BookService.Domain.Services.BookService(_bookRepository);

        //Act
        var result = await bookService.GetBooksAsync();

        //Assert
        result.Should().NotBeNull();
    }

}

