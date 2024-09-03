using AutoMapper;
using MediatR;
using Recipe.Application.Dtos.Comments;
using Recipe.Application.Features.Queries.Comment;
using Recipe.Application.Interfaces.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Recipe.Application.Features.Handlers.QueryHandlers.Comment
{
    public class GetRecipeCommentByUserIdHandler : IRequestHandler<GetRecipeCommentByUserIdQuery, List<CommentsWithRecipesDto>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public GetRecipeCommentByUserIdHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<List<CommentsWithRecipesDto>> Handle(GetRecipeCommentByUserIdQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.getRecipeCommentByUserId(request.UserId);
            var commentDtos = _mapper.Map<List<CommentsWithRecipesDto>>(comments);
            var commentDict = commentDtos.ToDictionary(x => x.Id);

            foreach (var comment in comments)
            {
                if (commentDict.TryGetValue(comment.Id, out var commentDto))
                {
                    commentDto.LikeCount = comment.CommentLikes.Count;
                    commentDto.IsLiked = comment.CommentLikes.Any(x => x.UserId == request.UserId);
                }
            }
            return commentDtos;
        }

    }
}
