#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace ValidatingFormSubmission.Models;


public class User
{
    [Required(ErrorMessage = "First Name here is Required")]
    [MinLength(4)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name here is Required")]
    [MinLength(4)]
    public string LastName { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Age { get; set; }

    [Required]
    [EmailAddress]
    public string EmailAdress { get; set; }

     [Required]
     [MinLength(8)]
    public string Password { get; set; } 
}