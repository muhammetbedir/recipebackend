using AutoMapper;
using MediatR;
using Recipe.Application.Features.Commands.Comment;
using Recipe.Application.Repository;
using Recipe.Domain.Models;

namespace Recipe.Application.Features.Handlers.CommandHandlers.Comment
{
    internal class DeleteSubCommentByIdHandler : IRequestHandler<DeleteSubCommentByIdCommand>
    {
        private readonly IGenericRepository<SubComentEntity> _subCommentRepository;
        private readonly IMapper _mapper;

        public DeleteSubCommentByIdHandler(IMapper mapper, IGenericRepository<SubComentEntity> subCommentRepository)
        {
            _mapper = mapper;
            _subCommentRepository = subCommentRepository;
        }

        public async Task Handle(DeleteSubCommentByIdCommand request, CancellationToken cancellationToken)
        {
            var comment = await _subCommentRepository.GetByIdAsync(request.Id.Value);
            await _subCommentRepository.deleteAsync(comment);
            await _subCommentRepository.CommitAsync();
        }
    }
}
