using AutoMapper;
using SimpleHealthyRecipes.DTOs;
using SimpleHealthyRecipes.Models;
using SimpleHealthyRecipes.Requests.Recipe;

namespace SimpleHealthyRecipes.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RecipeModel, DetailedRecipeDTO>()
            .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.Ratings.Any() ? src.Ratings.Average(r => r.Stars) : 0))
            .ForMember(dest => dest.TotalRatings, opt => opt.MapFrom(src => src.Ratings.Count))
            .ReverseMap();

        CreateMap<RecipeModel, BaseRecipeDTO>()
            .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.Ratings.Any() ? src.Ratings.Average(r => r.Stars) : 0))
            .ReverseMap();

        CreateMap<IngredientModel, IngredientDTO>().ReverseMap();
        CreateMap<TagModel, TagDTO>().ReverseMap();
        CreateMap<RecipeStepModel, RecipeStepDTO>().ReverseMap();
        CreateMap<CategoryModel, CategoryDTO>().ReverseMap();
        CreateMap<CuisineModel, CuisineDTO>().ReverseMap();

        CreateMap<RecipeIngredientModel, RecipeIngredientDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IngredientId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Ingredient != null ? src.Ingredient.Name : string.Empty))
            .ReverseMap()
            .ForPath(src => src.IngredientId, opt => opt.MapFrom(dto => dto.Id))
            .ForPath(src => src.Ingredient.Name, opt => opt.Ignore());

    }
}