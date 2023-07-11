namespace LandingPage.Lora.Domain.DTOs.Inputs;

public class PersonRegisterInput
{
    public string Name { get; set; }
    public string Email { get; set; }
    public bool OptinMarket { get; set; }
    public bool OptinTerms { get; set; }
}