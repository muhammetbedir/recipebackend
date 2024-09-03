using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipe.Application.Dtos.Common;
using Recipe.Application.Features.Commands.Category;
using Recipe.Application.Features.Commands.Recipe;
using Recipe.Application.Features.Queries.Category;
using Recipe.Common.Helpers;
using Recipe.Presentation.Dtos.Category;
using Recipe.Presentation.Dtos.Common;
using Recipe.Presentation.Dtos.Recipe;

namespace Recipe.Api.Controllers
{
    [Authorize(Roles =UserRoles.Admin)]
    public class CategoryController : BaseController
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator) => _mediator = mediator;

        [AllowAnonymous]
        [HttpGet("[Action]")]
        public async Task<BaseResponseDto<List<CategoryDto>>> GetCategories([FromQuery] GetCategoriesQuery request)
        {
            try
            {
                return BaseResponseDto<List<CategoryDto>>.Success(await _mediator.Send(request));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost("[Action]")]
        public async Task<BaseResponseDto<AddResponseDto>> AddCategory([FromBody] AddCategoryCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return BaseResponseDto<AddResponseDto>.Success(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPut("[Action]")]
        public async Task<BaseResponseDto<NoContentDto>> UpdateCategory([FromBody] UpdateCategoryCommand request)
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
        [HttpDelete("[Action]/{Id:Guid}")]
        public async Task<BaseResponseDto<NoContentDto>> DeleteCategory([FromRoute] DeleteCategoryCommand request)
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
