namespace LandingPage.Lora.Domain.Entities;

public class Message : Entity<Guid>
{
    public Guid PersonId { get; set; }
    public String Content { get; set; }
    public DateTime CreatedAt { get; set; }
}