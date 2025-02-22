using SimpleHealthyRecipes.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace SimpleHealthyRecipes.Models;

public class MovieReferenceModel : BaseEntity<int>
{
    [Required]
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<RecipeModel> Recipes { get; set; } = [];
}
