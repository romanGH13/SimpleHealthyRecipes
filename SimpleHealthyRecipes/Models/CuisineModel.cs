using SimpleHealthyRecipes.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace SimpleHealthyRecipes.Models;

public class CuisineModel : BaseEntity<int>
{
    [Required]
    public string Name { get; set; } = string.Empty;
    public List<RecipeModel> Recipes { get; set; } = [];
}