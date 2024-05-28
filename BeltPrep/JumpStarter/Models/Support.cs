#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace JumpStarter.Models;
public class Support
{
    
    [Key]
    public int SupportId  { get; set; }

    [Required(ErrorMessage = "SupportAmount is required!")]
    [Range(0,int.MaxValue, ErrorMessage = "SupportAmount must be a positive whole number!")]
    public int SupportAmount  { get; set; } 
    [Required]
    public int UserId { get; set; }
    public User? User { get; set; }
    [Required]
    public int ProjectId { get; set; }
    public Project? Project { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}