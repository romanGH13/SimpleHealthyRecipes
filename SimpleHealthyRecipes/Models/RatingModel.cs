using SimpleHealthyRecipes.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace SimpleHealthyRecipes.Models;

public class RatingModel : BaseEntity<int>
{
    [Range(1, 5)]
    public int Stars { get; set; }
    public string Comment { get; set; } = string.Empty;

    public int RecipeId { get; set; }
    public RecipeModel? Recipe { get; set; }
}