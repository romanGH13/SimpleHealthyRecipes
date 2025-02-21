namespace SimpleHealthyRecipes.DTOs;

public record RecipeSummaryDTO
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public int PrepTimeMinutes { get; init; }
    public int CookTimeMinutes { get; init; }
    public int Servings { get; init; }
    public double AverageRating { get; init; }

    public RecipeSummaryDTO() { }
}
