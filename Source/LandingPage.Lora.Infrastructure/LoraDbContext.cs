using Microsoft.EntityFrameworkCore;

namespace LandingPage.Lora.Infrastructure
{
    public class LoraDbContext: DbContext
    {
        public LoraDbContext(DbContextOptions<LoraDbContext> options) : base(options)
        {
        }

        // public DbSet<Log> Logs { get; set; }
    }
}