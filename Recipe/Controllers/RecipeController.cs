using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipe.Application.Dtos.Recipe;
using Recipe.Application.Features.Commands.Recipe;
using Recipe.Application.Features.Queries.Recipe;
using Recipe.Presentation.Dtos.Common;
using Recipe.Presentation.Dtos.Recipe;

namespace Recipe.Api.Controllers
{
    [AllowAnonymous]
    public class RecipeController : BaseController
    {
        private readonly IMediator _mediator;
        public RecipeController(IMediator mediator) => _mediator = mediator;

        [HttpGet("[Action]")]
        public async Task<BaseResponseDto<List<GetAllRecipesDto>>> GetRecipesByPage([FromQuery] GetRecipesByPageQuery request)
        {
            try
            {
                return BaseResponseDto<List<GetAllRecipesDto>>.Success(await _mediator.Send(request));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("[Action]")]
        public async Task<BaseResponseDto<int>> GetRecipeCount([FromQuery] GetRecipeCountQuery request)
        {
            try
            {
                return BaseResponseDto<int>.Success(await _mediator.Send(request));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [AllowAnonymous]
        [HttpGet("[Action]")]
        public async Task<BaseResponseDto<List<GetAllRecipesDto>>> GetPopularRecipesByPage([FromQuery] GetPopularRecipesByPageQuery request)
        {
            try
            {
                return BaseResponseDto<List<GetAllRecipesDto>>.Success(await _mediator.Send(request));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [AllowAnonymous]
        [HttpGet("[Action]")]
        public async Task<BaseResponseDto<List<GetAllRecipesDto>>> GetWeeklyPopularRecipesByPage([FromQuery] GetWeeklyPopularRecipesByPageQuery request)
        {
            try
            {
                return BaseResponseDto<List<GetAllRecipesDto>>.Success(await _mediator.Send(request));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("[Action]")]
        public async Task<BaseResponseDto<List<GetAllRecipesDto>>> GetLatestRecipesByPage([FromQuery] GetLatestRecipesByPageQuery request)
        {
            try
            {
                return BaseResponseDto<List<GetAllRecipesDto>>.Success(await _mediator.Send(request));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("[Action]")]
        public async Task<BaseResponseDto<int>> GetRecipeCountByCategoryAndPage([FromQuery] GetRecipeCountByCategoryAndPageQuery request)
        {
            try
            {
                return BaseResponseDto<int>.Success(await _mediator.Send(request));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("[Action]")]
        public async Task<BaseResponseDto<List<GetAllRecipesDto>>> GetRecipesByCategoryAndPage([FromQuery] GetRecipesByCategoryAndPageQuery request)
        {
            try
            {
                return BaseResponseDto<List<GetAllRecipesDto>>.Success(await _mediator.Send(request));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("[Action]")]
        public async Task<BaseResponseDto<GetRecipeByIdDto>> GetRecipesById([FromQuery] GetRecipesByIdQuery request)
        {
            try
            {
                return BaseResponseDto<GetRecipeByIdDto>.Success(await _mediator.Send(request));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Authorize]
        [HttpPost("[Action]")]
        public async Task<BaseResponseDto<AddRecipeDto>> AddRecipe([FromBody] AddRecipeCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return BaseResponseDto<AddRecipeDto>.Success(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPut("[Action]")]
        public async Task<BaseResponseDto<NoContentDto>> UpdateRecipe([FromBody] UpdateRecipeCommand request)
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
        [Authorize]
        [HttpDelete("[Action]/{Id:Guid}")]
        public async Task<BaseResponseDto<NoContentDto>> DeleteRecipe([FromRoute] DeleteRecipeCommand request)
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
        [Authorize]
        [HttpPost("[Action]")]
        public async Task<BaseResponseDto<NoContentDto>> AddRecipeTutorialPictures([FromBody] AddRecipeTutorialPicturesComand request)
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

        [HttpGet("[Action]")]
        public async Task<BaseResponseDto<List<GetAllRecipesDto>>> GetRecipeByUserId([FromQuery] GetRecipeByUserIdQuery request)
        {
            try
            {
                return BaseResponseDto<List<GetAllRecipesDto>>.Success(await _mediator.Send(request));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("[Action]")]
        public async Task<BaseResponseDto<List<GetAllRecipesDto>>> GetBookedRecipeByUserId([FromQuery] GetBookedRecipeByUserIdQuery request)
        {
            try
            {
                return BaseResponseDto<List<GetAllRecipesDto>>.Success(await _mediator.Send(request));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AllowAnonymous]
        [HttpGet("search")]
        public async Task<BaseResponseDto<List<GetAllRecipesDto>>> SearchRecipes([FromQuery] string query)
        {
            return BaseResponseDto<List<GetAllRecipesDto>>.Success(await _mediator.Send(new SearchRecipesQuery(query)));
        }
    }
}
