using AutoMapper;
using Recipe.Application.Dtos.Book;
using Recipe.Application.Features.Commands.Book;
using Recipe.Domain.Models;

namespace Recipe.Application.Mapping
{
    public class BookConfig : Profile
    {
        public BookConfig()
        {
            CreateMap<BookEntity, BookDto>();
            CreateMap<AddRecipeToBookCommand, BookEntity>();
        }
    }
}
