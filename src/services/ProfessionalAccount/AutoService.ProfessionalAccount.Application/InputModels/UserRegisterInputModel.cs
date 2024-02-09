using System.ComponentModel.DataAnnotations;

namespace AutoService.ProfessionalAccount.Application.InputModels
{
    public class UserRegisterInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PasswordConfirmed { get; set; }

        public string CPF { get; set; }

        public string  Name { get; set; }
    }
}
