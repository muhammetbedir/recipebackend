using AutoMapper;
using MediatR;
using Recipe.Application.Dtos.Comments;
using Recipe.Application.Features.Queries.Comment;
using Recipe.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Recipe.Application.Features.Handlers.QueryHandlers.Comment
{
    public class GetRecipeCommentsByPageHandler : IRequestHandler<GetRecipeCommentsByPageQuery, List<CommentDto>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public GetRecipeCommentsByPageHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<List<CommentDto>> Handle(GetRecipeCommentsByPageQuery request, CancellationToken cancellationToken)
        {
            var data = await _commentRepository.getRecipeCommentsByPage(request);
            var response = _mapper.Map<List<CommentDto>>(data);
            var commentDict = response.ToDictionary(x => x.Id);
            
            foreach (var comment in data)
            {
                if (commentDict.TryGetValue(comment.Id, out var commentDto))
                {
                    commentDto.LikeCount = comment.CommentLikes.Count;
                    commentDto.IsLiked = comment.CommentLikes.Any(x => x.UserId == request.UserId);
                    foreach (var subComment in comment.SubComents)
                    {
                        var subCommentDto = commentDto.SubComents.FirstOrDefault(x => x.Id == subComment.Id);
                        if (subCommentDto != null)
                        {
                            subCommentDto.LikeCount = subComment.CommentLikes.Count;
                            subCommentDto.IsLiked = subComment.CommentLikes.Any(x => x.UserId == request.UserId);
                        }
                    }
                }
            }
            return response;
        }

    }
}
