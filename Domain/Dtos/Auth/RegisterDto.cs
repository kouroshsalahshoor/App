using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Auth
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string? Phone { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [Required] 
        public string Role { get; set; }
    }
}
