#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategories.Models;

public class Category
{
    [Key]
    [Required]
    public int CategoryId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<Association> MyProducts { get; set; } = new List<Association>();

}