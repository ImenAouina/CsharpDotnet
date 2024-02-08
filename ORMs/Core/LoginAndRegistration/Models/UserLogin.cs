#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;


namespace LoginAndRegistration.Models;

public class UserLogin 
{

    [Required]
    [EmailAddress]
    public string LoginEmail {get; set;}

    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string LoginPassword {get; set;}

}