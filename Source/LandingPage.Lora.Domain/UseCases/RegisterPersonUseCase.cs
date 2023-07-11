using AutoMapper;
using LandingPage.Lora.Core.Interfaces;
using LandingPage.Lora.Domain.DTOs.Inputs;
using LandingPage.Lora.Domain.Entities;
using LandingPage.Lora.Domain.Interfaces;

namespace LandingPage.Lora.Domain.UseCases;

public class RegisterPersonUseCase : IUseCase<PersonRegisterResponse, PersonRegisterInput>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public RegisterPersonUseCase(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<PersonRegisterResponse> Execute(PersonRegisterInput input)
    {
        DateTime CreatedAt = DateTime.Now;

        Person person  = new Person(){
            Id = Guid.NewGuid(),
            Name = input.Name,
            Email = input.Email,
            OptinMarket = input.OptinMarket,
            OptinTerms = input.OptinTerms,
            CreatedAt = CreatedAt
        };

        _uow.PersonRepository.Add(person);
        _uow.Commit();

        return await Task.FromResult( _mapper.Map<PersonRegisterResponse>(person));
    }
}