using FluentValidation;

namespace LandingPage.Lora.Api.Site.FormRequest;

public class PersonRegisterFormRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public bool OptinMarket { get; set; }
    public bool OptinTerms { get; set; }
}

public class PersonRegisterFormRequestValidator : AbstractValidator<PersonRegisterFormRequest>
{
    public PersonRegisterFormRequestValidator()
    {
        RuleFor(aa => aa.Name)
            .NotNull()
            .MaximumLength(100)
                .WithMessage("Name must be less than or equal to 100 characters.");
        RuleFor(aa => aa.Email)
            .NotNull()
            .EmailAddress()
                .WithMessage("Email must be valid.")
            .MaximumLength(100)
                .WithMessage("Email must be less than or equal to 100 characters.");
    }
}