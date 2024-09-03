using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipe.Application.Dtos.Comments;
using Recipe.Application.Features.Commands.Book;
using Recipe.Application.Features.Commands.Comment;
using Recipe.Application.Features.Commands.Recipe;
using Recipe.Application.Features.Queries.Comment;
using Recipe.Presentation.Dtos.Common;
using Recipe.Presentation.Dtos.Recipe;

namespace Recipe.Api.Controllers
{
    public class CommentController : BaseController
    {
        private readonly IMediator _mediator;
        public CommentController(IMediator mediator) => _mediator = mediator;
        [HttpPost("[Action]")]
        public async Task<BaseResponseDto<NoContentDto>> AddCommentToRecipe([FromBody] AddCommentToRecipeCommand request)
        {
            try
            {
                await _mediator.Send(request);
                return BaseResponseDto<NoContentDto>.Success();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost("[Action]")]
        public async Task<BaseResponseDto<NoContentDto>> AddSubCommentToRecipe([FromBody] AddSubCommentToRecipeCommand request)
        {
            try
            {
                await _mediator.Send(request);
                return BaseResponseDto<NoContentDto>.Success();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [AllowAnonymous]
        [HttpGet("[Action]")]
        public async Task<BaseResponseDto<List<CommentDto>>> GetRecipeCommentsByPage([FromQuery] GetRecipeCommentsByPageQuery request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return BaseResponseDto<List<CommentDto>>.Success(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [AllowAnonymous]
        [HttpGet("[Action]")]
        public async Task<BaseResponseDto<int>> GetRecipeCommentCount([FromQuery] GetRecipeCommentCountQuery request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return BaseResponseDto<int>.Success(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("[Action]")]
        public async Task<BaseResponseDto<List<CommentsWithRecipesDto>>> GetRecipeCommentByUserId([FromQuery] GetRecipeCommentByUserIdQuery request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return BaseResponseDto<List<CommentsWithRecipesDto>>.Success(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("[Action]/{id:Guid}")]
        public async Task<BaseResponseDto<NoContentDto>> DeleteCommentById([FromRoute] DeleteCommentByIdCommand request)
        {
            try
            {
                await _mediator.Send(request);
                return BaseResponseDto<NoContentDto>.Success();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("[Action]/{id:Guid}")]
        public async Task<BaseResponseDto<NoContentDto>> DeleteSubCommentById([FromRoute] DeleteSubCommentByIdCommand request)
        {
            try
            {
                await _mediator.Send(request);
                return BaseResponseDto<NoContentDto>.Success();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("[Action]")]
        public async Task<BaseResponseDto<NoContentDto>> LikeComment([FromBody] LikeCommentCommand request)
        {
            try
            {
                await _mediator.Send(request);
                return BaseResponseDto<NoContentDto>.Success();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost("[Action]")]
        public async Task<BaseResponseDto<NoContentDto>> RemoveLikeFromComment([FromBody] RemoveLikeFromCommentCommand request)
        {
            try
            {
                await _mediator.Send(request);
                return BaseResponseDto<NoContentDto>.Success();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
