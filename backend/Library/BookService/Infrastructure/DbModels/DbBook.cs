using System.ComponentModel.DataAnnotations.Schema;

namespace BookService.Infrastructure.DbModels
{
    public class DbBook
    {
        [Column("Id")]
        public Guid Id { get; set; }
        
        [Column("Title")]
        public string Title { get; set; }
        
        [Column("Authors")]
        public string Authors { get; set; }
        
        [Column("Description")]
        public string? Description { get; set; }
        
        [Column("Publisher")]
        public string? Publisher { get; set; }
        
        [Column("Category")]
        public string? Category { get; set; }
        
        [Column("Publish_Month")]
        public string Month { get; set; }
        
        [Column("Publish_Year")]
        public int Year { get; set; }
        
        [Column("Price")]
        public string Price { get; set; }
    }
}
