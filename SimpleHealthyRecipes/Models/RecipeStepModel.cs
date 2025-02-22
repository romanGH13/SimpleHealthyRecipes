using SimpleHealthyRecipes.Models.Base;

namespace SimpleHealthyRecipes.Models;

public class RecipeStepModel : BaseEntity<int>
{
    public int StepNumber { get; set; }
    public string Instruction { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }

    public int RecipeId { get; set; }
    public RecipeModel? Recipe { get; set; }
}