namespace SimpleHealthyRecipes.DTOs;

public record RecipeDTO
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public int PrepTimeMinutes { get; init; }
    public int CookTimeMinutes { get; init; }
    public int Servings { get; init; }
    public bool IsVegetarian { get; init; }
    public List<IngredientDTO> Ingredients { get; init; } = new();
    public List<TagDTO> Tags { get; init; } = new();
    public double AverageRating { get; init; }
    public int TotalRatings { get; init; }

    
    public RecipeDTO() { }
}
