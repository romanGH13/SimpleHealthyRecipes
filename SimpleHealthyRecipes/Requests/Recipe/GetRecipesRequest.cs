namespace SimpleHealthyRecipes.Requests.Recipe;

using SimpleHealthyRecipes.Requests.Base;

public record GetRecipesRequest(
    string? SearchTerm,
    bool? IsVegetarian,
    int? MinPrepTime,
    int? MaxPrepTime,
    int? MinCookTime,
    int? MaxCookTime,
    int Page = 1,
    int PageSize = 10
) : BasePaginationRequest(Page, PageSize);