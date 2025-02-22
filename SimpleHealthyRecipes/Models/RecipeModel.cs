using System.ComponentModel.DataAnnotations;
using SimpleHealthyRecipes.Enums;
using SimpleHealthyRecipes.Models.Base;

namespace SimpleHealthyRecipes.Models;

public class RecipeModel : DeletableEntity<int>
{
    [Required]
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string? VideoUrl { get; set; }
    public int PrepTimeMinutes { get; set; }
    public int CookTimeMinutes { get; set; }
    public int Servings { get; set; }
    public DifficultyLevel Difficulty { get; set; }

    public List<IngredientModel> Ingredients { get; set; } = [];
    public List<CategoryModel> Categories { get; set; } = [];
    public List<TagModel> Tags { get; set; } = [];
    public List<RatingModel> Ratings { get; set; } = [];
    public List<RecipeStepModel> Steps { get; set; } = [];

    public int? CuisineId { get; set; }
    public CuisineModel? Cuisine { get; set; }

    public int? MovieReferenceId { get; set; }
    public MovieReferenceModel? MovieReference { get; set; }
}