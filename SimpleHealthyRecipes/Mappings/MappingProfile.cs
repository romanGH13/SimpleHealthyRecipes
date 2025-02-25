using AutoMapper;
using SimpleHealthyRecipes.DTOs;
using SimpleHealthyRecipes.Models;
using SimpleHealthyRecipes.Requests.Recipe;

namespace SimpleHealthyRecipes.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Мапінг Recipe → DetailedRecipeDTO
        CreateMap<RecipeModel, DetailedRecipeDTO>()
            .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.Ratings.Any() ? src.Ratings.Average(r => r.Stars) : 0))
            .ForMember(dest => dest.TotalRatings, opt => opt.MapFrom(src => src.Ratings.Count))
            .ReverseMap();

        // Мапінг Recipe → BaseRecipeDTO
        CreateMap<RecipeModel, BaseRecipeDTO>()
            .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.Ratings.Any() ? src.Ratings.Average(r => r.Stars) : 0))
            .ReverseMap();

        // Мапінг Ingredient → IngredientDTO
        CreateMap<IngredientModel, IngredientDTO>().ReverseMap();

        // Мапінг Tag → TagDTO
        CreateMap<TagModel, TagDTO>().ReverseMap();


        // Мапінг RecipeStep → RecipeStepDTO
        CreateMap<RecipeStepModel, RecipeStepDTO>().ReverseMap();

        // Мапінг Category → CategoryDTO
        CreateMap<CategoryModel, CategoryDTO>().ReverseMap();
    }
}