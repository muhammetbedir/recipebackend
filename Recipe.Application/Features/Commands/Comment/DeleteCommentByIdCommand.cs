using MediatR;

namespace Recipe.Application.Features.Commands.Comment
{
    public class DeleteCommentByIdCommand : IRequest
    {
        public Guid? Id { get; set; }
    }
}
