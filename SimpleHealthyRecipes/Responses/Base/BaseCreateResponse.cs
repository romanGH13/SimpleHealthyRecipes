namespace SimpleHealthyRecipes.Responses.Base;

public abstract record BaseCreateResponse<T>(string Message, bool Success, T Id) : BaseResponse(Message, Success);
