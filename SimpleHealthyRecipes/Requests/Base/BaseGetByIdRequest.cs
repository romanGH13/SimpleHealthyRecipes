using System.ComponentModel.DataAnnotations;

namespace SimpleHealthyRecipes.Requests.Base;

public abstract record BaseGetByIdRequest(
    [Required] int Id
) : BaseRequest;