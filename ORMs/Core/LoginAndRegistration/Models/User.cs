#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginAndRegistration.Models;

public class User 
{
    [Key]
    public int UserId {get; set;}
    [Required(ErrorMessage ="FirstName is required!!")]
    [Display(Name ="First Name")]
    public string FirstName {get; set;}

    [Required(ErrorMessage ="LastName is required!!")]
    [Display(Name ="Last Name")]
    public string LastName {get; set;}

    [Required(ErrorMessage ="Email is required!!")]
    [EmailAddress]
    public string Email {get; set;}

    [Required(ErrorMessage ="Password is required!!")]
    [MinLength(8, ErrorMessage ="Password must be at least 8 char!!")]
    [DataType(DataType.Password)]
    public string Password {get; set;}

    [NotMapped]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage ="Password and confirm pass must much ")]
    [Display(Name ="Confirm Password")]
    public string PassConfirm {get; set;}

    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

}