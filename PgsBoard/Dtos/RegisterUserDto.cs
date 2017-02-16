using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PgsBoard.Dtos
{
    public class RegisterUserDto
    {
        [DisplayName("Nazwa użytkownika")]
        [Required]
        public string Username { get; set; }
        [DisplayName("Hasło")]
        [Required]
        public string Password { get; set; }
        [DisplayName("Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}