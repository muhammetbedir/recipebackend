using MediatR;

namespace Recipe.Application.Features.Commands.Comment
{
    public class DeleteSubCommentByIdCommand : IRequest
    {
        public Guid? Id { get; set; }
    }
}
