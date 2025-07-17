namespace DocuFlow.Application.DTO
{
    public class UserDto
    {
        //id username, email, role
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "user";

    }
}