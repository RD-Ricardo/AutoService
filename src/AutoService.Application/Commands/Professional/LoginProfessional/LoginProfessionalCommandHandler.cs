using AutoService.Core.Abstractions.CQRS.Handlers;
using AutoService.Core.Web;
using AutoService.Core.Web.Authentication;
using AutoService.Domain.Interfaces;

namespace AutoService.Application.Commands.Professional.LoginProfessional
{
    public class LoginProfessionalCommandHandler : CommandHandler<LoginProfessionalCommand, string>
    {
        private readonly IAuthenticateService _authenticateService;
        
        private readonly IProfessionalRepository _professionalRepository;

        public LoginProfessionalCommandHandler(IAuthenticateService authenticateService, IProfessionalRepository professionalRepository)
        {
            _authenticateService = authenticateService;
            _professionalRepository = professionalRepository;
        }

        public override async Task<RequestResult<string>> Handle(LoginProfessionalCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authenticateService.ComputeSha256Hash(request.Password);

            var professional = await _professionalRepository.LoginAsync(request.Email, passwordHash);

            if (professional is null)
                return Fail("Professional not found");

            string token = _authenticateService.CreateToken(professional.Id, professional.Email, professional.Permission.ToString());

            return Success(token);
        }
    }
}
