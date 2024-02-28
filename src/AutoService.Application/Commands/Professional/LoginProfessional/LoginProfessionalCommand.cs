using AutoService.Core.Abstractions.CQRS;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AutoService.Application.Commands.Professional.LoginProfessional
{
    public class LoginProfessionalCommand : Command<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        
        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
