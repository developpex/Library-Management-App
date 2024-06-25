namespace BookService.Domain.Models;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Authors { get; set; }
    public string? Description { get; set; }
    public string? Publisher { get; set; }
    public string? Category { get; set; }
    public string Month { get; set; }
    public int Year { get; set; }
    public string Price { get; set; }
}