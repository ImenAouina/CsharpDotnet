#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace BookStore.Models;
public class Book
{
    [Key]
    public int BookId { get; set; }

    [Required(ErrorMessage = "Title is required !!!!!!!")]
    [MinLength(2, ErrorMessage = "Title  must be at least 2 characters")]
    public string Title { get; set; }
    public int UserId { get; set; }
    // Navigation property for related User object
    public User? Author { get; set; } 

    [Required]
    public int PublicationYear { get; set; }
    public string? Description { get; set; }
    public bool IsAvailable  { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

     // navigation properties many to many
    public List<Like> Likes { get; set; } = new List<Like>(); 

}