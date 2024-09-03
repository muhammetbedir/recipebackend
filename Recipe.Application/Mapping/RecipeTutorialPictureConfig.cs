using AutoMapper;
using Recipe.Application.Dtos.Recipe;
using Recipe.Application.Features.Commands.Recipe;
using Recipe.Domain.Models;

namespace Recipe.Application.Mapping
{
    public class RecipeTutorialPictureConfig : Profile
    {
        public RecipeTutorialPictureConfig()
        {
            CreateMap<AddRecipeTutorialPicturesComand, RecipeTutorialPictureEntity>();
            CreateMap<RecipeTutorialPictureDto, RecipeTutorialPictureEntity>().ReverseMap();
        }
    }
}
