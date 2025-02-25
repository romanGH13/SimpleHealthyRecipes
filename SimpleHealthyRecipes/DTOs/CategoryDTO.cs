namespace SimpleHealthyRecipes.DTOs;

public record CategoryDTO
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public CategoryDTO() { }
}