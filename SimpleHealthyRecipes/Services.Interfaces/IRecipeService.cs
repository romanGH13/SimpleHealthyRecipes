using SimpleHealthyRecipes.DTOs;
using SimpleHealthyRecipes.Requests.Recipe;
using SimpleHealthyRecipes.Responses.Base;
using SimpleHealthyRecipes.Responses.Recipe;

namespace SimpleHealthyRecipes.Services.Interfaces;

public interface IRecipeService
{
    Task<PagedResponse<RecipeSummaryDTO>> GetAllAsync(GetRecipesRequest request);
    Task<RecipeResponse> GetByIdAsync(GetRecipeByIdRequest request);
    Task<CreateRecipeResponse> CreateAsync(CreateRecipeRequest request);
    Task<RecipeResponse> UpdateAsync(UpdateRecipeRequest request);
    Task<DeleteRecipeResponse> DeleteAsync(DeleteRecipeRequest request);
}