using System.ComponentModel.DataAnnotations;
using SimpleHealthyRecipes.Models.Base;

namespace SimpleHealthyRecipes.Models;

public class Recipe : DeletableEntity<int>
{
    [Required]
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int PrepTimeMinutes { get; set; }
    public int CookTimeMinutes { get; set; }
    public int Servings { get; set; }

    public bool IsFreezable { get; set; }
    public bool IsEggFree { get; set; }
    public bool IsHealthy { get; set; }
    public bool IsLowCalorie { get; set; }
    public bool IsVegetarian { get; set; }

    public List<Ingredient> Ingredients { get; set; } = [];
    public List<Category> Categories { get; set; } = [];
    public List<Tag> Tags { get; set; } = [];
    public List<Rating> Ratings { get; set; } = [];
}