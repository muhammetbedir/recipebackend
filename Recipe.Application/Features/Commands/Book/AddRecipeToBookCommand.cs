using MediatR;
using Recipe.Application.Dtos.Book;
using Recipe.Domain.Models;

namespace Recipe.Application.Features.Commands.Book
{
    public class AddRecipeToBookCommand : IRequest<BookDto>
    {
        public Guid? RecipeId { get; set; }
        public Guid? UserId { get; set; }
    }
}
