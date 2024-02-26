#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ECommerce.Models;
public class Product
{
    
    [Key]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Product Name  is required !!!!!!!")]
    [Display(Name = "Product Name")]
    public string ProductName { get; set; }

    public string? Image { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
     public int Quantity { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
     // navigation properties Many To Many
    public List<Order> OrderedBy { get; set; } = new List<Order>();

}