using AutoService.Core.Abstractions.UseCases;
using AutoService.Core.Web;
using AutoService.Core.Web.Authentication;
using AutoService.ProfessionalAccount.Application.InputModels;
using AutoService.ProfessionalAccount.Domain.Interfaces;

namespace AutoService.ProfessionalAccount.Application.UseCases.LoginUser
{
    public class UserLoginUseCase : IUseCase<UserLoginInputModel, string>
    {
        private readonly IAuthenticateService _authenticateService;
        
        private readonly IProfessionalRepository _professionalRepository;

        public UserLoginUseCase(IAuthenticateService authenticateService, IProfessionalRepository professionalRepository)
        {
            _authenticateService = authenticateService;
            _professionalRepository = professionalRepository;
        }

        public async Task<RequestResult<string>> Execute(UserLoginInputModel parameter)
        {
            var passwordHash = _authenticateService.ComputeSha256Hash(parameter.Password);

            var professional = await _professionalRepository.LoginAsync(parameter.Email, passwordHash);

            if (professional is null)
                return new RequestResult<string>(false, "erro");

            string token = _authenticateService.CreateToken(professional.Id, professional.Email, professional.Permission.ToString());

            return new RequestResult<string>(true, token);
        }
    }
}
