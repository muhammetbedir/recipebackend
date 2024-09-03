using MediatR;

namespace Recipe.Application.Features.Commands.User
{
    public class ChangeUserNameCommand : IRequest
    {
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
    }
}
