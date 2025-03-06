using SimpleHealthyRecipes.Enums;

namespace SimpleHealthyRecipes.DTOs;

public record DetailedRecipeDTO : BaseRecipeDTO
{
    public string? VideoUrl { get; init; }

    public List<RecipeIngredientDTO> Ingredients { get; init; } = [];
    public List<TagDTO> Tags { get; init; } = [];
    public List<RecipeStepDTO> Steps { get; init; } = [];
    public int TotalRatings { get; init; }

    public int? CuisineId { get; init; }
    public CuisineDTO? Cuisine { get; init; }

    public int? MovieReferenceId { get; init; }
    public MovieReferenceDTO? MovieReference { get; init; }
    public DetailedRecipeDTO() { }
}