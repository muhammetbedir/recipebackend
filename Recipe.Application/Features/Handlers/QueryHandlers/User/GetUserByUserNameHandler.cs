using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Recipe.Application.Dtos.User;
using Recipe.Application.Features.Queries.Auth;
using Recipe.Application.Interfaces.Repository;
using Recipe.Common.Exceptions;
using Recipe.Domain.Models;

namespace Recipe.Application.Features.Handlers.QueryHandlers.Auth
{
    public class GetUserByUserNameHandler : IRequestHandler<GetUserByUserNameQuery, UserProfileDto>
    {
        private readonly IUserRepository _userManager;
        private readonly IFollowRepository _followRepository;
        private readonly IMapper _mapper;
        public GetUserByUserNameHandler(IUserRepository userManager, IMapper mapper, IFollowRepository followRepository)
        {
            _userManager = userManager;
            _mapper = mapper;
            _followRepository = followRepository;
        }
        public async Task<UserProfileDto> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.getUserByUserName(request.UserName);
            if (user == null)
            {
                throw new RecipeException("Kullanıcı bulunamadı.", 404);
            }
            var responseDto = _mapper.Map<UserProfileDto>(user);
            var followed = await _followRepository.getFollowedCount(user.Id);
            var follower = await _followRepository.getFollowerCount(user.Id);
            responseDto.FollowerCount = follower;
            responseDto.FollowedCount = followed;
            responseDto.IsFollowing = user.Followers.Any(x=>x.FollowerId == request.CurrentUserId);
            return responseDto;
        }
    }
}
