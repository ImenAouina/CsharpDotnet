#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key]
    public int UserId { get; set; }

    // ---------------------FirstName------------------------------------
    [Required(ErrorMessage = "First name is required !!!!!!!")]
    [MinLength(2, ErrorMessage = "First name must be at least 2 ❌❌❌")]
    public string FirstName { get; set; }
    // ---------------------LastName------------------------------------
    [Required(ErrorMessage = "Last name is required !!!!!!!")]
    [MinLength(2, ErrorMessage = "Last name must be at least 2 ❌❌❌")]
    public string LastName { get; set; }

    // ------------------------Email---------------------------------
    [Required(ErrorMessage = "Email address must be present 😡😡😡")]
    [EmailAddress] // Email Pattern (= REGEX)
    public string Email { get; set; }

    // --------------------------Password----------------------------
    [Required(ErrorMessage = "Password is very required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    [DataType(DataType.Password)] // To hide the password Input in The Views
    public string Password { get; set; }

    // -----------------------Confirm Password---------------------------------
    [NotMapped] // Do not add this field to DB
    [Compare("Password", ErrorMessage = "Password & Confirm Password must match")]
    [DataType(DataType.Password)] // To hide the Confirm password Input  in The Views
    [Display(Name = "Confirm Password")]
    public string Confirm { get; set; }

    // -----------------------Created At--------------------------------
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // ----------------------------Updated At-------------------------------
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Todo> MyTodos { get; set; } = new List<Todo>();

    public List<Delegation> MyDelegatedTodos { get; set; } = new List<Delegation>();
}