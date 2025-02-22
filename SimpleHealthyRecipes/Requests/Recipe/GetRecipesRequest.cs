namespace SimpleHealthyRecipes.Requests.Recipe;

using SimpleHealthyRecipes.Enums;
using SimpleHealthyRecipes.Requests.Base;

public record GetRecipesRequest(
    string? SearchTerm,
    List<string>? Tags,
    int? MinPrepTime,
    int? MaxPrepTime,
    int? MinCookTime,
    int? MaxCookTime,
    int? MinServings,
    int? MaxServings,
    DifficultyLevel? Difficulty,
    int? CuisineId,
    int Page = 1,
    int PageSize = 10
) : BasePaginationRequest(Page, PageSize);