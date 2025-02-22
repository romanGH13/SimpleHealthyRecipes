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

public class RecipeService(IRecipeRepository recipeRepository, ITagRepository tagRepository, IMapper mapper) : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository = recipeRepository;

    public async Task<PagedResponse<BaseRecipeDTO>> GetAllAsync(GetRecipesRequest request)
    {
        var recipes = await _recipeRepository.GetFilteredRecipesAsync(request);
        var recipeDTOs = recipes.Select(r => new BaseRecipeDTO
        {
            Id = r.Id,
            Title = r.Title,
            PrepTimeMinutes = r.PrepTimeMinutes,
            CookTimeMinutes = r.CookTimeMinutes,
            Servings = r.Servings,
            AverageRating = r.Ratings.Any() ? r.Ratings.Average(r => r.Stars) : 0
        }).ToList();

        return new PagedResponse<BaseRecipeDTO>("Recipes retrieved successfully",
            true,
            recipeDTOs,
            request.Page,
            request.PageSize,
            recipes.Count);
    }

    public async Task<DetailedRecipeDTO> GetByIdAsync(GetRecipeByIdRequest request)
    {
        var recipe = await _recipeRepository.GetByIdWithDetailsAsync(request.Id);
        if (recipe == null)
            throw new KeyNotFoundException("Recipe not found");

        return mapper.Map<DetailedRecipeDTO>(recipe);
    }

    public async Task<CreateRecipeResponse> CreateAsync(CreateRecipeRequest request)
    {
        var newRecipe = new RecipeModel
        {
            Title = request.Title,
            Description = request.Description,
            PrepTimeMinutes = request.PrepTimeMinutes,
            CookTimeMinutes = request.CookTimeMinutes,
            Servings = request.Servings,
            CuisineId = request.CuisineId,
            Difficulty = request.Difficulty,
            Ingredients = request.Ingredients.Select(i => new IngredientModel
            {
                Name = i.Name,
                Quantity = i.Quantity,
                Unit = i.Unit
            }).ToList(),
            Steps = request.Steps.Select(s => new RecipeStepModel
            {
                StepNumber = s.StepNumber,
                Instruction = s.Instruction,
                ImageUrl = s.ImageUrl
            }).ToList()
        };

        // Обробка тегів: знайти існуючі, створити нові
        var existingTags = await tagRepository.GetByNamesAsync(request.Tags);
        var existingTagNames = existingTags.Select(t => t.Name).ToHashSet();
        var newTags = request.Tags.Where(tag => !existingTagNames.Contains(tag))
                                  .Select(tag => new TagModel { Name = tag }).ToList();

        // Додаємо існуючі та нові теги
        newRecipe.Tags = existingTags.Concat(newTags).ToList();

        await recipeRepository.AddAsync(newRecipe);
        await tagRepository.AddRangeAsync(newTags); // Додаємо нові теги в БД

        return new CreateRecipeResponse(
            "Recipe created successfully",
            true,
            newRecipe.Id
        );
    }

    public async Task<DetailedRecipeDTO> UpdateAsync(UpdateRecipeRequest request)
    {
        var recipe = await _recipeRepository.GetByIdWithDetailsAsync(request.Id);
        if (recipe == null)
            throw new KeyNotFoundException("Recipe not found");

        recipe.Title = request.Title;
        recipe.Description = request.Description;
        recipe.PrepTimeMinutes = request.PrepTimeMinutes;
        recipe.CookTimeMinutes = request.CookTimeMinutes;
        recipe.Servings = request.Servings;
        recipe.CuisineId = request.CuisineId;
        recipe.Difficulty = request.Difficulty;

        // Оновлення тегів
        var existingTags = await tagRepository.GetByNamesAsync(request.Tags);
        var existingTagNames = existingTags.Select(t => t.Name).ToHashSet();
        var newTags = request.Tags.Where(tag => !existingTagNames.Contains(tag))
                                  .Select(tag => new TagModel { Name = tag }).ToList();

        recipe.Tags = existingTags.Concat(newTags).ToList();
        await tagRepository.AddRangeAsync(newTags);

        await _recipeRepository.UpdateAsync(recipe);
        return await GetByIdAsync(new GetRecipeByIdRequest(recipe.Id));
    }

    public async Task<DeleteRecipeResponse> DeleteAsync(DeleteRecipeRequest request)
    {
        var recipe = await _recipeRepository.GetByIdWithDetailsAsync(request.Id);
        if (recipe == null)
            throw new KeyNotFoundException("Recipe not found");

        await _recipeRepository.DeleteAsync(recipe.Id);
        return new DeleteRecipeResponse(
            "Recipe deleted successfully",
            true
        );
    }
}
