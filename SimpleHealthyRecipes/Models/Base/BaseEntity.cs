namespace SimpleHealthyRecipes.Models.Base;


public abstract class BaseEntity<T> : IEntity<T>, ITrackable
{
    public T Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
}
