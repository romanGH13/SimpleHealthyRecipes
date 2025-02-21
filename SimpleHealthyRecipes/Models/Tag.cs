using System.ComponentModel.DataAnnotations;
using SimpleHealthyRecipes.Models.Base;

namespace SimpleHealthyRecipes.Models;

public class Tag : BaseEntity<int>
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public List<Recipe> Recipes { get; set; } = [];
}
