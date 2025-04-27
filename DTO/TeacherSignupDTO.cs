using System.ComponentModel.DataAnnotations;
using WebAppDBMVC01.Core.enums;
using WebAppDBMVC01.Data;

namespace WebAppDBMVC01.DTO
{
    public class TeacherSignupDTO
    {
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Username must be between 2 and  50 characters.")]
        public string? Username { get; set; }

        [StringLength(100,  ErrorMessage = "Email must not exceed 100 characters")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, and one number.")]
        public string? Password { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Firstname must be between 2 and  50 characters.")]

        public string? Firstname { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Lastname must be between 2 and  50 characters.")]

        public string? Lastname { get; set; }

        [StringLength(15, MinimumLength = 10, ErrorMessage = "Phone number must be at least 10 digits long and  not exceed 15 digits.")]

        public string? PhoneNumber { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Institution must be between 2 and  50 characters.")]

        public string? Institution { get; set; }

        [EnumDataType(typeof(UserRole), ErrorMessage = "Invalid user role.")]   
        public UserRole? UserRole { get; set; }

       
    }
}
