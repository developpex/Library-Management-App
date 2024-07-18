using BookService.Application.Contracts;
using BookService.Domain.Models;

namespace BookService.Domain.Interfaces;

public interface IMapper
{
    BookDto Map(Book book);
}