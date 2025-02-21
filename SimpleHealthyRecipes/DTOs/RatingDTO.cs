namespace SimpleHealthyRecipes.DTOs;

public record RatingDTO
{
    public int Stars { get; init; }
    public string Comment { get; init; } = string.Empty;

    public RatingDTO() { }
}
