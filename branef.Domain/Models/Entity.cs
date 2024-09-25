namespace branef.Domain.Models;

public abstract class Entity
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; private set; }

    public void SetId() => Id = Guid.NewGuid();
    public void SetUpdateDate() => UpdatedAt = DateTime.Now;
}