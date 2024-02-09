using AutoService.Core.Abstractions.UseCases;
using AutoService.Core.Web;
using AutoService.Core.Web.Authentication;
using AutoService.ProfessionalAccount.Application.InputModels;
using AutoService.ProfessionalAccount.Domain.Entities;
using AutoService.ProfessionalAccount.Domain.Interfaces;

namespace AutoService.ProfessionalAccount.Application.UseCases.RegisterUser
{
    public class UserRegisterUseCase : IUseCase<UserRegisterInputModel, string>
    {
        private readonly IAuthenticateService _authenticateService;
        
        private readonly IProfessionalRepository _professionalRepository;
        
        public UserRegisterUseCase(IAuthenticateService authenticateService, 
            IProfessionalRepository professionalRepository)
        {
            _authenticateService = authenticateService;
            _professionalRepository = professionalRepository;
        }

        public async Task<RequestResult<string>> Execute(UserRegisterInputModel parameter)
        {
            var passwordHash = _authenticateService.ComputeSha256Hash(parameter.Password);

            Professional professional = new(parameter.Name, passwordHash, parameter.Email, parameter.CPF);

            await _professionalRepository.RegisterAsync(professional);
            
            var result = await _professionalRepository.UnitOfWork.Commit();

            if (!result)
                return new RequestResult<string>(false, null, "erro");

            return new RequestResult<string>(true, professional.Id.ToString());
        }
    }
}
