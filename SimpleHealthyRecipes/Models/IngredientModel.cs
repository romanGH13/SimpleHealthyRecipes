using SimpleHealthyRecipes.Enums;
using SimpleHealthyRecipes.Models.Base;
using System.ComponentModel.DataAnnotations;


namespace SimpleHealthyRecipes.Models;

public class IngredientModel : BaseEntity<int>
{
    [Required]
    public required string Name { get; set; }
    [Required]
    public double Quantity { get; set; }
    [Required]
    public MeasurementUnit Unit { get; set; }

    public int RecipeId { get; set; }
    public RecipeModel? Recipe { get; set; }
}
