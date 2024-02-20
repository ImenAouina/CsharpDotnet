#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;
public class User
{
    
    [Key]
    public int UserId { get; set; }

    [Required(ErrorMessage = "First name is required !!!!!!!")]
    [MinLength(2, ErrorMessage = "First name must be at least 2")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Last name is required !!!!!!!")]
    [MinLength(2, ErrorMessage = "Last name must be at least 2")]
    public string LastName { get; set; }

   
    [Required(ErrorMessage = "Email address must be present")]
    [EmailAddress]
    public string Email { get; set; }

    
    [Required(ErrorMessage = "Password is very required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    [DataType(DataType.Password)] 
    public string Password { get; set; }

    
    [NotMapped] 
    [Compare("Password", ErrorMessage = "Password & Confirm Password must match")]
    [DataType(DataType.Password)] 
    [Display(Name = "Confirm Password")]
    public string Confirm { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // navigation properties one to many
    public List<Wedding> MyWeddings { get; set; } = new List<Wedding>();
     // navigation properties many to many
    public List<Attendance> MyAttendances { get; set; } = new List<Attendance>();

}