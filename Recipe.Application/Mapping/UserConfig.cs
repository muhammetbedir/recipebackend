using AutoMapper;
using Recipe.Application.Dtos.User;
using Recipe.Application.Features.Commands.Recipe;
using Recipe.Application.Features.Commands.User;
using Recipe.Domain.Models;

namespace Recipe.Application.Mapping
{
    public class UserConfig : Profile
    {
        public UserConfig()
        {
            CreateMap<UserEntity, UserProfileDto>();
            CreateMap<ChangeUserInfoCommand, UserEntity>();
        }
    }
}
