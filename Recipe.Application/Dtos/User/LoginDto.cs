namespace Recipe.Application.Dtos.User
{
    public class LoginDto
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string UserName { get; set; }
        public string Role {  get; set; }
        public string ProfilePicture { get; set; }
    }
}
