using MediatR;

namespace Recipe.Application.Features.Commands.Book
{
    public class DeleteRecipeFromBookCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
