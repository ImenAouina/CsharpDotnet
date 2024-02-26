#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace TasksApp.Models;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options) { }
    // ! Don't forget to add all needed models
    public DbSet<Todo> Todos { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Delegation> Delegations { get; set; }
}