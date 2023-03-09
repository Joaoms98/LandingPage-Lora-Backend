namespace LandingPage.Lora.Domain.Entities.Interfaces;

public interface IHasSoftDelete
{
    public DateTime? DeletedAt { get; set; }
}
