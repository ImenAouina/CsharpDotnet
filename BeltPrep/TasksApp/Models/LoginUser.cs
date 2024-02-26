#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class LoginUser
{
    // ------------------------Email---------------------------------
    [Required(ErrorMessage = "Email address must be present 😡😡😡")]
    [EmailAddress] // Email Pattern (= REGEX)
    [Display(Name = "Email")]
    public string LoginEmail { get; set; }

    // --------------------------Password----------------------------
    [Required(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    [DataType(DataType.Password)] // To hide the password Input in The Views
    [Display(Name = "Password")]
    public string LoginPassword { get; set; }

}