using LandingPage.Lora.Domain.Entities;
using LandingPage.Lora.Domain.Interfaces;

namespace LandingPage.Lora.Infrastructure.Repositories;

public class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository(LoraDbContext dbContext) : base(dbContext)
    {
    }
}