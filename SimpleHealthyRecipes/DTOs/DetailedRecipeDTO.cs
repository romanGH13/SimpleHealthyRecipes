using SimpleHealthyRecipes.Enums;

namespace SimpleHealthyRecipes.DTOs;

public record DetailedRecipeDTO : BaseRecipeDTO
{
    public string Description { get; init; } = string.Empty;
    public string? ImageUrl { get; init; }
    public string? VideoUrl { get; init; }
    public DifficultyLevel Difficulty { get; init; }

    public List<IngredientDTO> Ingredients { get; init; } = [];
    public List<TagDTO> Tags { get; init; } = [];
    public List<RecipeStepDTO> Steps { get; init; } = [];
    public int TotalRatings { get; init; }

    public int? CuisineId { get; init; }
    public CuisineDTO? Cuisine { get; init; }

    public int? MovieReferenceId { get; init; }
    public MovieReferenceDTO? MovieReference { get; init; }
    public DetailedRecipeDTO() { }
}