#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ECommerce.Models;
public class Order
{
    
    [Key]
    public int OrderId  { get; set; }
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be positive")]
    public int Quantity { get; set; }
    [Required]
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    [Required]
    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}