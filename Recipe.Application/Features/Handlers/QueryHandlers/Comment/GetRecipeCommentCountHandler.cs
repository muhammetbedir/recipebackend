using AutoMapper;
using MediatR;
using Recipe.Application.Features.Queries.Comment;
using Recipe.Application.Interfaces.Repository;

namespace Recipe.Application.Features.Handlers.QueryHandlers.Comment
{
    public class GetRecipeCommentCountHandler : IRequestHandler<GetRecipeCommentCountQuery, int>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public GetRecipeCommentCountHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(GetRecipeCommentCountQuery request, CancellationToken cancellationToken)
        {
            return await _commentRepository.getCommentCountByRecipeId(request.RecipeId);
        }
    }
}
