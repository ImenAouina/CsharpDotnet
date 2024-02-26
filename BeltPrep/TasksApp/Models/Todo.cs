#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class Todo
{
    [Key]
    public int TodoId { get; set; }
    [Required(ErrorMessage = "You have to add a name!!")]
    public string Name { get; set; }
    public int UserId { get; set; }
    public string? Description { get; set; }
    public enum StatusEnum { ToDo, InProgress, Completed }
    public StatusEnum Status { get; set; } = StatusEnum.ToDo;

    // -----------------------Created At--------------------------------
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    // ----------------------------Updated At-------------------------------
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Navigation Properties
    public User? Publisher { get; set; }

    public List<Delegation> UsersInCharge { get; set; } = new List<Delegation>();
}
