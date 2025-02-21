using SimpleHealthyRecipes.Enums;
using System.ComponentModel.DataAnnotations;

namespace SimpleHealthyRecipes.Requests.Ingredient;

public record CreateIngredientRequest(
    [Required] string Name,
    [Range(0.01, double.MaxValue, ErrorMessage = "Quantity must be greater than 0")] double Quantity,
    [Required] MeasurementUnit Unit
);