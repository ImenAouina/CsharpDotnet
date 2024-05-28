#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace JumpStarter.Models;
public class Project
{
    
    [Key]
    public int ProjectId { get; set; }

     // navigation properties one to many 
    public int UserId { get; set; }
    // Navigation property for related User object
    public User? Creator { get; set; }


    [Required(ErrorMessage = "Title is required!")]
    public string Title  { get; set; }

     [Required(ErrorMessage = "Goal is required!")]
     [Range(0,int.MaxValue,ErrorMessage = "Goal must be a positive Integer!")]
    public int Goal  { get; set; }

    [Required(ErrorMessage = "Date is required")]
    [DataType(DataType.DateTime)] 
    public DateTime Date { get; set; }

    
    [Required(ErrorMessage = "Description is required!")]
    [MinLength(20,ErrorMessage = "Description must have 20 characters at least")]
    public string Description  { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
     // navigation properties Many To Many
    public List<Support> Supporters { get; set; } = new List<Support>();
}