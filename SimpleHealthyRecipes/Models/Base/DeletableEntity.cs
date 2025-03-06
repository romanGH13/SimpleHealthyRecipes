namespace SimpleHealthyRecipes.Models.Base;

public abstract class DeletableEntity<T> : BaseEntity<T>, IDeletable
     where T : struct, IEquatable<T>
{
    public bool IsDeleted { get; set; } = false;
}
