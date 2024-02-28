using AutoService.Core.Abstractions.CQRS;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AutoService.Application.Commands.Professional.CreateProfessional
{
    public class CreateProfessionalCommand : Command<Unit>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmed { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }

        public override bool Validate()
        {
           return ValidationResult.IsValid;
        }
    }
}
