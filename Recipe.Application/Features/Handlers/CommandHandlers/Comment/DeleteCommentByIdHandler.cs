using AutoMapper;
using MediatR;
using Recipe.Application.Features.Commands.Comment;
using Recipe.Application.Repository;
using Recipe.Domain.Models;

namespace Recipe.Application.Features.Handlers.CommandHandlers.Comment
{
    internal class DeleteCommentByIdHandler : IRequestHandler<DeleteCommentByIdCommand>
    {
        private readonly IGenericRepository<CommentEntity> _commentRepository;
        private readonly IMapper _mapper;

        public DeleteCommentByIdHandler(IMapper mapper, IGenericRepository<CommentEntity> commentRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        public async Task Handle(DeleteCommentByIdCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(request.Id.Value);
            await _commentRepository.deleteAsync(comment);
            await _commentRepository.CommitAsync();
        }
    }
}
