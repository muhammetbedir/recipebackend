using AutoMapper;
using MediatR;
using Recipe.Application.Features.Commands.Comment;
using Recipe.Application.Interfaces.Repository;
using Recipe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Features.Handlers.CommandHandlers.Comment
{
    public class AddCommentToRecipeHandler : IRequestHandler<AddCommentToRecipeCommand>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public AddCommentToRecipeHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task Handle(AddCommentToRecipeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CommentEntity>(request);
            await _commentRepository.InsertAsync(entity);
            await _commentRepository.CommitAsync();
        }
    }
}
