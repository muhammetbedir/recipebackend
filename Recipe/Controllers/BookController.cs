using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Application.Dtos.Book;
using Recipe.Application.Features.Commands.Book;
using Recipe.Application.Features.Queries.Category;
using Recipe.Presentation.Dtos.Category;
using Recipe.Presentation.Dtos.Common;

namespace Recipe.Api.Controllers
{

    public class BookController : BaseController
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator) => _mediator = mediator;

        [HttpGet("[Action]")]
        public async Task<BaseResponseDto<List<CategoryDto>>> GetUserBooksByPage([FromQuery] GetCategoriesQuery request)
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
        public async Task<BaseResponseDto<BookDto>> AddRecipeToBook([FromBody] AddRecipeToBookCommand request)
        {
            try
            {
                return BaseResponseDto<BookDto>.Success(await _mediator.Send(request));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpDelete("[Action]/{Id:Guid}")]
        public async Task<BaseResponseDto<NoContentDto>> DeleteRecipeFromBook([FromRoute] DeleteRecipeFromBookCommand request)
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
