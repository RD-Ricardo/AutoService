using System.ComponentModel.DataAnnotations;

namespace AutoService.ProfessionalAccount.Application.InputModels
{
    public class UserLoginInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
