namespace SimpleHealthyRecipes.Responses.Base;

public record PagedResponse<T>(
    string Message,
    bool Success,
    List<T> Items,
    int Page,
    int PageSize,
    int TotalCount
) : BaseResponse(Message, Success);
