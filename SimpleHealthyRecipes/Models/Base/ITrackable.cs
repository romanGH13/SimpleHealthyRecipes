namespace SimpleHealthyRecipes.Models.Base;

public interface ITrackable
{
    DateTime CreatedAt { get; set; }
    DateTime ModifiedAt { get; set; }
}
