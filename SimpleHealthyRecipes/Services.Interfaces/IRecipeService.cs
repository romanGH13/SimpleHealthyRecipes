using SimpleHealthyRecipes.DTOs;
using SimpleHealthyRecipes.Requests.Recipe;
using SimpleHealthyRecipes.Responses.Base;
using SimpleHealthyRecipes.Responses.Recipe;

namespace SimpleHealthyRecipes.Services.Interfaces;

public interface IRecipeService
{
    Task<PagedResponse<BaseRecipeDTO>> GetAllAsync(GetRecipesRequest request);
    Task<DetailedRecipeDTO> GetByIdAsync(GetRecipeByIdRequest request);
    Task<CreateRecipeResponse> CreateAsync(CreateRecipeRequest request);
    Task<DetailedRecipeDTO> UpdateAsync(UpdateRecipeRequest request);
    Task<DeleteRecipeResponse> DeleteAsync(DeleteRecipeRequest request);
}