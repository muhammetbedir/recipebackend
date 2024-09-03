using MediatR;

namespace Recipe.Application.Features.Commands.Category
{
    public class DeleteCategoryCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
