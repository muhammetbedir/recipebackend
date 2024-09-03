using MediatR;

namespace Recipe.Application.Features.Commands.User
{
    public class ChangeUserInfoCommand : IRequest
    {
        public Guid? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public string About { get; set; }   
        public string PhoneNumber { get; set; }
    }
}

