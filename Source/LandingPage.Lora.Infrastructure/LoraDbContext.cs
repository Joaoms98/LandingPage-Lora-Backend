using LandingPage.Lora.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LandingPage.Lora.Infrastructure
{
    public class LoraDbContext: DbContext
    {
        public LoraDbContext(DbContextOptions<LoraDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
    }
}