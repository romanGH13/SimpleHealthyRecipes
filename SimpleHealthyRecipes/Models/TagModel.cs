using System.ComponentModel.DataAnnotations;
using SimpleHealthyRecipes.Models.Base;

namespace SimpleHealthyRecipes.Models;

public class TagModel : BaseEntity<int>
{
    [Required]
    public string Name { get; set; } = string.Empty;
    public List<RecipeModel> Recipes { get; set; } = [];
}