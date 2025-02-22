namespace SimpleHealthyRecipes.DTOs;

public record CuisineDTO
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public CuisineDTO() { }
}