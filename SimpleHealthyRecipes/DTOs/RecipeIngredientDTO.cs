using SimpleHealthyRecipes.Enums;

namespace SimpleHealthyRecipes.DTOs;
public record RecipeIngredientDTO
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public double Quantity { get; init; }
    public MeasurementUnit Unit { get; init; }

    public RecipeIngredientDTO() { }
}