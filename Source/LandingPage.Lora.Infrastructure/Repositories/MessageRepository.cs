using LandingPage.Lora.Domain.Entities;
using LandingPage.Lora.Domain.Interfaces;

namespace LandingPage.Lora.Infrastructure.Repositories;

public class MessageRepository : Repository<Message>, IMessageRepository
{
    public MessageRepository(LoraDbContext dbContext) : base(dbContext)
    {
    }
}