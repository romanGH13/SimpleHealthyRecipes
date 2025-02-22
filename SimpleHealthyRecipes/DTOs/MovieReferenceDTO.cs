namespace SimpleHealthyRecipes.DTOs;

public record MovieReferenceDTO
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public MovieReferenceDTO() { }
}