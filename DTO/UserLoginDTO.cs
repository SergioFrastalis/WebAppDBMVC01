using System.ComponentModel.DataAnnotations;

namespace WebAppDBMVC01.DTO
{
    public class UserLoginDTO
    {
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Username must be between 2 and  50 characters.")]

        public string? Username { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, and one number.")]

        public string? Password { get; set; }

        public bool KeepLoggedIn { get; set; } 
    }
}
