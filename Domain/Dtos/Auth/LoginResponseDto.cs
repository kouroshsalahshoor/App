namespace Domain.Dtos.Auth
{
    public class LoginResponseDto
    {
        public ApplicationUser User { get; set; }
        public string Token { get; set; }
    }
}
