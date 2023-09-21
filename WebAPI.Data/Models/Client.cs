namespace WebAPI.Data.Models;

public class Client
{
    public Guid Id { get; set; }
    public string Initials { get; set; } = null!;
    public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;
    public DateTime DateOfRegistration { get; set; } = DateTime.UtcNow;

    public List<Purchase> Purchases { get; set; } = new();
}