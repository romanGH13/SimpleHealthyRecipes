namespace SimpleHealthyRecipes.Models.Base;

public abstract class DeletableEntity<T> : BaseEntity<T>, IDeletable
{
    public bool IsDeleted { get; set; } = false;
}
