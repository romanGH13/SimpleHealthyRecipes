namespace SimpleHealthyRecipes.DTOs;

public record RecipeStepDTO
{
    public int StepNumber { get; init; }
    public string Instruction { get; init; } = string.Empty;
    public string? ImageUrl { get; init; }
    public RecipeStepDTO() { }
}