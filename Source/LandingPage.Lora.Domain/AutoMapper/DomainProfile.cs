using AutoMapper;
using LandingPage.Lora.Domain.DTOs.Inputs;
using LandingPage.Lora.Domain.Entities;

namespace LandingPage.Lora.Domain.AutoMapper;

public class DomainProfile : Profile
{
    public DomainProfile()
    {
        CreateMap<Person, PersonRegisterResponse>(MemberList.Destination);
    }
}