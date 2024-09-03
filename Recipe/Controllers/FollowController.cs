using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Application.Dtos.Common;
using Recipe.Application.Features.Commands.Category;
using Recipe.Application.Features.Commands.Follow;
using Recipe.Presentation.Dtos.Common;

namespace Recipe.Api.Controllers
{
    public class FollowController : BaseController
    {
        private readonly IMediator _mediator;
        public FollowController(IMediator mediator) => _mediator = mediator;

        [HttpPost("[Action]")]
        public async Task<BaseResponseDto<NoContentDto>> Follow([FromBody] FollowCommand request)
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
        public async Task<BaseResponseDto<NoContentDto>> UnFollow([FromBody] UnFollowCommand request)
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
