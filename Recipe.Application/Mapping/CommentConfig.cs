using AutoMapper;
using Recipe.Application.Dtos.Comments;
using Recipe.Application.Features.Commands.Comment;
using Recipe.Application.Features.Queries.Comment;
using Recipe.Domain.Models;

namespace Recipe.Application.Mapping
{
    public class CommentConfig : Profile
    {
        public CommentConfig()
        {
            CreateMap<GetRecipeCommentsByPageQuery, CommentEntity>();
            CreateMap<CommentEntity, CommentDto>();
            CreateMap<AddCommentToRecipeCommand, CommentEntity>();
            CreateMap<AddSubCommentToRecipeCommand, SubComentEntity>();
            CreateMap<SubComentEntity, SubCommentDto>();
            CreateMap<CommentEntity, CommentsWithRecipesDto>();
        }
    }
}
