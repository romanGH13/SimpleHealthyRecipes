namespace SimpleHealthyRecipes.Responses.Base;

public abstract record BaseDataResponse<T>(string Message, bool Success, T? Data) : BaseResponse(Message, Success);
