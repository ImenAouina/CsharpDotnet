#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ECommerce.Models;
public class Customer
{
    
    [Key]
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "Customer Name  is required !!!!!!!")]
    [Display(Name = "Customer Name")]
    public string CustomerName { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
     // navigation properties Many To Many
    public List<Order> MyProducts { get; set; } = new List<Order>();

}