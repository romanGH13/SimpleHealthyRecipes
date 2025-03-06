using Microsoft.EntityFrameworkCore;
using SimpleHealthyRecipes.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace SimpleHealthyRecipes.Models;

[Index(nameof(Name), IsUnique = true)]
public class IngredientModel : BaseEntity<int>
{

    [Required]
    [MaxLength(128)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public decimal CaloriesPer100g { get; set; }

    [Required]
    public decimal ProteinPer100g { get; set; }

    [Required]
    public decimal FatPer100g { get; set; }

    [Required]
    public decimal CarbohydratesPer100g { get; set; }

    public List<RecipeIngredientModel> RecipeIngredients { get; set; } = [];
}
