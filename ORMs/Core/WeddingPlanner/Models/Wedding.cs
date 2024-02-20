#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;
public class Wedding
{
    
    [Key]
    public int WeddingId { get; set; }

     // navigation properties one to many 
    public int UserId { get; set; }
    // Navigation property for related User object
    public User? Creator { get; set; }


    [Required(ErrorMessage = "WedderOne  is required !!!!!!!")]
    public string WedderOne { get; set; }

    
    [Required(ErrorMessage = "WedderTow is required !!!!!!!")]
    public string WedderTow { get; set; }


    [Required(ErrorMessage = "Date is required")]
    [DataType(DataType.Date)] 
    public DateTime Date { get; set; }


    [Required(ErrorMessage = "Address is required")]
    [MinLength(2, ErrorMessage = "Address must be at least 2")]
    public string Address { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
     // navigation properties Many To Many
    public List<Attendance> MyGuests { get; set; } = new List<Attendance>();

}