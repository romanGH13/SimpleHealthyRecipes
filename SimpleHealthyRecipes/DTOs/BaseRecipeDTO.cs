using SimpleHealthyRecipes.Enums;

namespace SimpleHealthyRecipes.DTOs;

public record BaseRecipeDTO
{
    public int Id { get; init; }

    public string? ImageUrl { get; init; }
    public string Description { get; init; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public int PrepTimeMinutes { get; init; }
    public int CookTimeMinutes { get; init; }
    public int Servings { get; init; }
    public double AverageRating { get; init; }

    public DifficultyLevel Difficulty { get; init; }

    public BaseRecipeDTO() { }
}