using LandingPage.Lora.Domain.Entities.Interfaces;

namespace LandingPage.Lora.Domain.Entities;

public abstract class Entity : IEntity
{
}

public abstract class Entity<TKey> : IEntity
{
    public virtual TKey Id { get; set; }
}
