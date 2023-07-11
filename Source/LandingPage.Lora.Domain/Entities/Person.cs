namespace LandingPage.Lora.Domain.Entities
{
    public class Person : Entity<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool OptinMarket { get; set; }
        public bool OptinTerms { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime SoftDeleteAt { get; set; }
    }
}