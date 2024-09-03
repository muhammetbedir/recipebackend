using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipe.Api.Controllers;
using Recipe.Application.Dtos.User;
using Recipe.Application.Features.Commands.Auth;
using Recipe.Application.Features.Commands.User;
using Recipe.Application.Features.Queries.Auth;
using Recipe.Presentation.Dtos.Common;

namespace Recipe.Controllers
{
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<BaseResponseDto<LoginDto>> Login([FromBody] UserLoginQuery request)
        {
            var userExists = await _mediator.Send(request);

            return BaseResponseDto<LoginDto>.Success(userExists);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<BaseResponseDto<LoginDto>> Register([FromBody] RegisterUserCommand request)
        {
            try
            {
                await _mediator.Send(request);
                return BaseResponseDto<LoginDto>.Success();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("register-admin")]
        public async Task<BaseResponseDto<LoginDto>> RegisterAdmin([FromBody] RegisterAdminCommand request)
        {
            try
            {
                await _mediator.Send(request);
                return BaseResponseDto<LoginDto>.Success();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("[Action]")]
        public async Task<BaseResponseDto<string>> GetUserRoleByUserId([FromQuery] GetUserRoleByUserIdQuery request)
        {
            try
            {
               
                return BaseResponseDto<string>.Success(await _mediator.Send(request));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("[Action]")]
        public async Task<BaseResponseDto<UserProfileDto>> GetUserByUserName([FromQuery] GetUserByUserNameQuery request)
        {
            try
            {

                return BaseResponseDto<UserProfileDto>.Success(await _mediator.Send(request));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("[Action]")]
        public async Task<BaseResponseDto<string>> UpsertUserProfilePicture([FromBody] UpsertUserProfilePictureCommand request)
        {
            try
            {
                return BaseResponseDto<string>.Success(await _mediator.Send(request));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<BaseResponseDto<NoContentDto>> ChangeEmail([FromBody] ChangeEmailCommand request)
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

        [HttpPost]
        [Route("[Action]")]
        public async Task<BaseResponseDto<NoContentDto>> ChangePassword([FromBody] ChangePasswordCommand request)
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

        [HttpPost]
        [Route("[Action]")]
        public async Task<BaseResponseDto<NoContentDto>> ChangeUserName([FromBody] ChangeUserNameCommand request)
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

        [HttpPost]
        [Route("[Action]")]
        public async Task<BaseResponseDto<NoContentDto>> ChangeUserInfo([FromBody] ChangeUserInfoCommand request)
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
