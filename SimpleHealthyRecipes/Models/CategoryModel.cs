using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using SimpleHealthyRecipes.Models.Base;

namespace SimpleHealthyRecipes.Models;

[Index(nameof(Name), IsUnique = true)]
public class CategoryModel : BaseEntity<int>
{
    [Required]
    [MaxLength(128)]
    public string Name { get; set; } = string.Empty;

    public List<RecipeModel> Recipes { get; set; } = [];
}
