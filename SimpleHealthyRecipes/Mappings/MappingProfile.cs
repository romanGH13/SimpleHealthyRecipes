using AutoMapper;
using SimpleHealthyRecipes.DTOs;
using SimpleHealthyRecipes.Models;

namespace SimpleHealthyRecipes.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Мапінг Recipe → RecipeDTO
        CreateMap<Recipe, RecipeDTO>()
            .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.Ratings.Any() ? src.Ratings.Average(r => r.Stars) : 0))
            .ForMember(dest => dest.TotalRatings, opt => opt.MapFrom(src => src.Ratings.Count))
            .ReverseMap();

        // Мапінг Recipe → RecipeSummaryDTO
        CreateMap<Recipe, RecipeSummaryDTO>()
            .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.Ratings.Any() ? src.Ratings.Average(r => r.Stars) : 0))
            .ReverseMap();

        // Мапінг Ingredient → IngredientDTO
        CreateMap<Ingredient, IngredientDTO>().ReverseMap();

        // Мапінг Tag → TagDTO
        CreateMap<Tag, TagDTO>().ReverseMap();
    }
}