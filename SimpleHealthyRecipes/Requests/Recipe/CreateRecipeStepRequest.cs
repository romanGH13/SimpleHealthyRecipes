using System.ComponentModel.DataAnnotations;

namespace SimpleHealthyRecipes.Requests.Recipe;

public record CreateRecipeStepRequest(
    [Required] int StepNumber,
    [Required] string Instruction,
    string? ImageUrl
);