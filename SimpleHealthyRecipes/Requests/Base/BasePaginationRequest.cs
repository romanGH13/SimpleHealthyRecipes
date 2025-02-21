namespace SimpleHealthyRecipes.Requests.Base;

public abstract record BasePaginationRequest(
    int Page = 1,
    int PageSize = 10
) : BaseRequest;
