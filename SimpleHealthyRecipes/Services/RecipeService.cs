using AutoMapper;
using SimpleHealthyRecipes.DTOs;
using SimpleHealthyRecipes.Extensions;
using SimpleHealthyRecipes.Models;
using SimpleHealthyRecipes.Repositories;
using SimpleHealthyRecipes.Repositories.Interfaces;
using SimpleHealthyRecipes.Requests.Ingredient;
using SimpleHealthyRecipes.Requests.Recipe;
using SimpleHealthyRecipes.Responses.Base;
using SimpleHealthyRecipes.Responses.Recipe;
using SimpleHealthyRecipes.Services.Interfaces;

namespace SimpleHealthyRecipes.Services;

public class RecipeService(IRecipeRepository recipeRepository, ITagRepository tagRepository, IMapper mapper, IIngredientRepository ingredientRepository) : IRecipeService
{

    public async Task<PagedResponse<BaseRecipeDTO>> GetAllAsync(GetRecipesRequest request)
    {
        var recipes = await recipeRepository.GetFilteredRecipesAsync(request);
        var recipeDTOs = mapper.Map<List<BaseRecipeDTO>>(recipes);

        return new PagedResponse<BaseRecipeDTO>("Recipes retrieved successfully",
            true,
            recipeDTOs,
            request.Page,
            request.PageSize,
            recipes.Count);
    }

    public async Task<DetailedRecipeDTO> GetByIdAsync(GetRecipeByIdRequest request)
    {
        var recipe = await recipeRepository.GetByIdWithDetailsAsync(request.Id);
        if (recipe == null)
            throw new KeyNotFoundException("Recipe not found");

        return mapper.Map<DetailedRecipeDTO>(recipe);
    }

    public async Task<CreateRecipeResponse> CreateAsync(CreateRecipeRequest request)
    {
        var recipeIngredients = await ProcessIngredientsAsync(request.Ingredients);
        var steps = ProcessSteps(request.Steps);
        var tags = await ProcessTagsAsync(request.Tags);

        var newRecipe = new RecipeModel
        {
            Title = request.Title,
            Description = request.Description,
            PrepTimeMinutes = request.PrepTimeMinutes,
            CookTimeMinutes = request.CookTimeMinutes,
            Servings = request.Servings,
            CuisineId = request.CuisineId,
            Difficulty = request.Difficulty,
            RecipeIngredients = recipeIngredients,
            Steps = steps,
            Tags = tags
        };

        await recipeRepository.AddAsync(newRecipe);
        return new CreateRecipeResponse("Recipe created successfully", true, newRecipe.Id);
    }

    private async Task<List<RecipeIngredientModel>> ProcessIngredientsAsync(List<CreateIngredientRequest> ingredientRequests)
    {
        var ingredientNames = ingredientRequests.Select(i => i.Name).Distinct().ToList();
        var existingIngredients = await ingredientRepository.GetByNamesAsync(ingredientNames);
        var existingIngredientDict = existingIngredients.ToDictionary(i => i.Name, i => i);

        var newIngredients = new List<IngredientModel>();
        var recipeIngredients = new List<RecipeIngredientModel>();

        foreach (var i in ingredientRequests)
        {
            if (!existingIngredientDict.TryGetValue(i.Name, out var ingredient))
            {
                ingredient = new IngredientModel
                {
                    Name = i.Name,
                    CaloriesPer100g = 0,
                    ProteinPer100g = 0,
                    FatPer100g = 0,
                    CarbohydratesPer100g = 0
                };
                newIngredients.Add(ingredient);
            }

            recipeIngredients.Add(new RecipeIngredientModel
            {
                Ingredient = ingredient,
                Quantity = i.Quantity,
                Unit = i.Unit
            });
        }

        await ingredientRepository.AddRangeAsync(newIngredients);
        return recipeIngredients;
    }

    private List<RecipeStepModel> ProcessSteps(List<CreateRecipeStepRequest> stepRequests)
    {
        return stepRequests.Select(s => new RecipeStepModel
        {
            StepNumber = s.StepNumber,
            Instruction = s.Instruction,
            ImageUrl = s.ImageUrl
        }).ToList();
    }

    private async Task<List<TagModel>> ProcessTagsAsync(List<string> tagNames)
    {
        var existingTags = await tagRepository.GetByNamesAsync(tagNames);
        var existingTagNames = existingTags.Select(t => t.Name).ToHashSet();
        var newTags = tagNames.Where(tag => !existingTagNames.Contains(tag))
                              .Select(tag => new TagModel { Name = tag }).ToList();

        await tagRepository.AddRangeAsync(newTags);
        return existingTags.Concat(newTags).ToList();
    }


    public async Task<DetailedRecipeDTO> UpdateAsync(UpdateRecipeRequest request)
    {
        var recipe = await recipeRepository.GetByIdWithDetailsAsync(request.Id);
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

        await recipeRepository.UpdateAsync(recipe);
        return await GetByIdAsync(new GetRecipeByIdRequest(recipe.Id));
    }

    public async Task<DeleteRecipeResponse> DeleteAsync(DeleteRecipeRequest request)
    {
        var recipe = await recipeRepository.GetByIdWithDetailsAsync(request.Id);
        if (recipe == null)
            throw new KeyNotFoundException("Recipe not found");

        await recipeRepository.DeleteAsync(recipe.Id);
        return new DeleteRecipeResponse(
            "Recipe deleted successfully",
            true
        );
    }
}
