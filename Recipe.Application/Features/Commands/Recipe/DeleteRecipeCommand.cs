using MediatR;

namespace Recipe.Application.Features.Commands.Recipe
{
    public class DeleteRecipeCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
