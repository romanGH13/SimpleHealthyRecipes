using SimpleHealthyRecipes.Enums;
using SimpleHealthyRecipes.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace SimpleHealthyRecipes.Models;

public class RecipeIngredientModel : BaseEntity<int>
{
    public int RecipeId { get; set; }
    public RecipeModel? Recipe { get; set; }

    public int IngredientId { get; set; }
    public IngredientModel? Ingredient { get; set; }

    [Required]
    public double Quantity { get; set; }

    [Required]
    public MeasurementUnit Unit { get; set; }
}