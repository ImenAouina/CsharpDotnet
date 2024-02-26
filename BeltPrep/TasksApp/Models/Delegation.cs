using System.ComponentModel.DataAnnotations;

public class Delegation
{
    [Key]
    public int DelegationId { get; set; }
    public int UserId { get; set; }
    public int TodoId { get; set; }

    // Navigation Prperties
    public User? User { get; set; }
    public Todo? Todo { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
