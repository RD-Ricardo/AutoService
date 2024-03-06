using AutoService.Core.Abstractions.CQRS;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AutoService.Application.Commands.Professional.CreateProfessional
{
    public class CreateProfessionalCommand(string email, string password, string passwordConfirmed, string cPF, string name) : Command<Unit>
    {
        public string Email { get; private set; } = email;
        public string Password { get; private set; } = password;
        public string PasswordConfirmed { get; private set; } = passwordConfirmed;
        public string CPF { get; private set; } = cPF;
        public string Name { get; private set; } = name;

        public override bool Validate()
        {
           return true;
        }
    }
}
