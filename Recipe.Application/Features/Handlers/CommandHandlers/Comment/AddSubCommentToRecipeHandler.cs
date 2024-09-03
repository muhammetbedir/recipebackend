using AutoMapper;
using MediatR;
using Recipe.Application.Features.Commands.Comment;
using Recipe.Application.Repository;
using Recipe.Domain.Models;

namespace Recipe.Application.Features.Handlers.CommandHandlers.Comment
{
    public class AddSubCommentToRecipeHandler : IRequestHandler<AddSubCommentToRecipeCommand>
    {
        private readonly IGenericRepository<SubComentEntity> _subCommentRepository;
        private readonly IMapper _mapper;

        public AddSubCommentToRecipeHandler(IMapper mapper, IGenericRepository<SubComentEntity> subCommentRepository)
        {
            _mapper = mapper;
            _subCommentRepository = subCommentRepository;
        }

        public async Task Handle(AddSubCommentToRecipeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SubComentEntity>(request);
            await _subCommentRepository.InsertAsync(entity);
            await _subCommentRepository.CommitAsync();
        }
    }
}
