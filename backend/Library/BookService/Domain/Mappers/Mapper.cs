using BookService.Application.Contracts;
using BookService.Domain.Interfaces;
using BookService.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace BookService.Domain.Mappers;

[Mapper]
public partial class Mapper : IMapper
{
    public partial BookDto Map(Book book);
}