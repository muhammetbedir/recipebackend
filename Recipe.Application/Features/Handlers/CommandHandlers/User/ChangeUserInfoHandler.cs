using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Recipe.Application.Features.Commands.User;
using Recipe.Common.Exceptions;
using Recipe.Domain.Models;

namespace Recipe.Application.Features.Handlers.CommandHandlers.User
{
    public class ChangeUserInfoHandler : IRequestHandler<ChangeUserInfoCommand>
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IMapper _mapper;

        public ChangeUserInfoHandler(UserManager<UserEntity> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task Handle(ChangeUserInfoCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
            {
                throw new RecipeException("Kullanıcı bulunamadı daha sonra tekrar deneyin.", 400);
            }
            var newUser = _mapper.Map(request, user);
            await _userManager.UpdateAsync(newUser);
        }
    }
}
