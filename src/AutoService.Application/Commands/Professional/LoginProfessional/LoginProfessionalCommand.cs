using AutoService.Core.Abstractions.CQRS;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AutoService.Application.Commands.Professional.LoginProfessional
{
    public class LoginProfessionalCommand : Command<string>
    {
        public LoginProfessionalCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
        
        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
