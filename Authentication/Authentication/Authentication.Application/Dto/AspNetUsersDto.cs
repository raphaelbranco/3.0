namespace Authentication.Application.Dto
{
    public class AspNetUsersDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? PhoneNumber { get; set; }
    }
}

