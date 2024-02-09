#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;


namespace LoginAndRegistration.Models;

public class UserLogin 
{

    [Required]
    [EmailAddress]
    [Display(Name ="Your Email")]
    public string LoginEmail {get; set;}

    [Required]
    [MinLength(8, ErrorMessage ="Password must be at least 8 char!!")]
    [DataType(DataType.Password)]
    [Display(Name ="Your Password")]
    public string LoginPassword {get; set;}

}