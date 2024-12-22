namespace Domain.Models;
public abstract class Entity
{
    public virtual Guid Id { get; private set; }
}
