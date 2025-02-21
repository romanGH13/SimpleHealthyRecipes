using System.ComponentModel.DataAnnotations;

namespace SimpleHealthyRecipes.Requests.Base;

public abstract record BaseDeleteRequest(
    [Required] int Id
) : BaseRequest;