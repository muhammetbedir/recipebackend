using AutoMapper;
using Recipe.Application.Dtos.Recipe;
using Recipe.Application.Dtos.User;
using Recipe.Application.Features.Commands.Recipe;
using Recipe.Domain.Models;
using Recipe.Presentation.Dtos.Category;
using Recipe.Presentation.Dtos.Recipe;

namespace Recipe.Application.Mapping
{
    public class RecipeConfig : Profile
    {
        public RecipeConfig()
        {
            CreateMap<RecipeEntity, GetAllRecipesDto>()
                .ForMember(dest => dest.BookedCount, opt => opt.MapFrom(src => src.Books.Count))
                .ReverseMap();
            CreateMap<RecipeEntity, AddRecipeDto>();
            CreateMap<RecipeEntity, AddRecipeCommand>();
            CreateMap<AddRecipeCommand, RecipeEntity>();
            CreateMap<UpdateRecipeCommand, RecipeEntity>();
            CreateMap<RecipeEntity, GetRecipeByIdDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
                //.ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));
            CreateMap<UserEntity, UserDto>();
        }
    }
}
