using AutoMapper;
using SimpleHealthyRecipes.DTOs;
using SimpleHealthyRecipes.Extensions;
using SimpleHealthyRecipes.Models;
using SimpleHealthyRecipes.Repositories;
using SimpleHealthyRecipes.Requests.Recipe;
using SimpleHealthyRecipes.Responses.Base;
using SimpleHealthyRecipes.Responses.Recipe;
using SimpleHealthyRecipes.Services.Interfaces;

namespace SimpleHealthyRecipes.Services;

public class RecipeService(IRecipeRepository recipeRepository, IMapper mapper) : IRecipeService
{
    public async Task<PagedResponse<RecipeSummaryDTO>> GetAllAsync(GetRecipesRequest request)
    {
        var query = recipeRepository.GetQueryable();

        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            query = query.Where(r => r.Title.Contains(request.SearchTerm) || r.Description.Contains(request.SearchTerm));
        }

        if (request.IsVegetarian.HasValue)
        {
            query = query.Where(r => r.IsVegetarian == request.IsVegetarian.Value);
        }

        if (request.MinPrepTime.HasValue)
        {
            query = query.Where(r => r.PrepTimeMinutes >= request.MinPrepTime.Value);
        }

        if (request.MaxPrepTime.HasValue)
        {
            query = query.Where(r => r.PrepTimeMinutes <= request.MaxPrepTime.Value);
        }

        var (Items, TotalCount) = await query.PageAsync(request);

        return new PagedResponse<RecipeSummaryDTO>(
            "Recipes retrieved successfully",
            true,
            mapper.Map<List<RecipeSummaryDTO>>(Items),
            request.Page,
            request.PageSize,
            TotalCount
        );
    }

    public async Task<RecipeResponse> GetByIdAsync(GetRecipeByIdRequest request)
    {
        var recipe = await recipeRepository.GetByIdWithDetailsAsync(request.Id);
        if (recipe == null)
        {
            return new RecipeResponse("Recipe not found", false, null);
        }
        var recipeDto = mapper.Map<RecipeDTO>(recipe);
        return new RecipeResponse("Recipe retrieved successfully", true, recipeDto);
    }

    public async Task<CreateRecipeResponse> CreateAsync(CreateRecipeRequest request)
    {
        var recipe = new Recipe
        {
            Title = request.Title,
            Description = request.Description,
            PrepTimeMinutes = request.PrepTimeMinutes,
            CookTimeMinutes = request.CookTimeMinutes,
            Servings = request.Servings,
            IsVegetarian = request.IsVegetarian,
            Ingredients = request.Ingredients.Select(i => new Ingredient
            {
                Name = i.Name,
                Quantity = i.Quantity,
                Unit = i.Unit
            }).ToList()
        };

        await recipeRepository.AddAsync(recipe);
        var recipeDto = mapper.Map<RecipeDTO>(recipe);
        return new CreateRecipeResponse("Recipe created successfully", true, recipeDto);
    }

    public async Task<RecipeResponse> UpdateAsync(UpdateRecipeRequest request)
    {
        var recipe = await recipeRepository.GetByIdWithDetailsAsync(request.Id);
        if (recipe == null)
        {
            return new RecipeResponse("Recipe not found", false, null);
        }

        // Оновлюємо поля рецепта
        recipe.Title = request.Title;
        recipe.Description = request.Description;
        recipe.PrepTimeMinutes = request.PrepTimeMinutes;
        recipe.CookTimeMinutes = request.CookTimeMinutes;
        recipe.Servings = request.Servings;
        recipe.IsVegetarian = request.IsVegetarian;

        // Припустимо, що оновлення інгредієнтів виконується повністю (можна розширити логику)
        recipe.Ingredients = request.Ingredients.Select(i => new Ingredient
        {
            Name = i.Name,
            Quantity = i.Quantity,
            Unit = i.Unit,
            RecipeId = recipe.Id
        }).ToList();

        await recipeRepository.UpdateAsync(recipe);
        var recipeDto = mapper.Map<RecipeDTO>(recipe);
        return new RecipeResponse("Recipe updated successfully", true, recipeDto);
    }

    public async Task<DeleteRecipeResponse> DeleteAsync(DeleteRecipeRequest request)
    {
        var recipe = await recipeRepository.GetByIdAsync(request.Id);
        if (recipe == null)
        {
            return new DeleteRecipeResponse("Recipe not found", false);
        }

        await recipeRepository.DeleteAsync(request.Id);
        return new DeleteRecipeResponse("Recipe deleted successfully", true);
    }
}
