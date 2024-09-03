using AutoMapper;
using Recipe.Application.Dtos.Common;
using Recipe.Application.Features.Commands.Category;
using Recipe.Domain.Models;
using Recipe.Presentation.Dtos.Category;

namespace Recipe.Application.Mapping
{
    public class CategoryConfig : Profile
    {
        public CategoryConfig()
        {
            CreateMap<CategoryEntity, CategoryDto>();
            CreateMap<AddCategoryCommand, CategoryDto>();
            CreateMap<AddCategoryCommand, CategoryEntity>();
            CreateMap<UpdateCategoryCommand, CategoryDto>();
            CreateMap<UpdateCategoryCommand, CategoryEntity>();
            CreateMap<CategoryEntity, AddResponseDto>();
        }
    }
}
