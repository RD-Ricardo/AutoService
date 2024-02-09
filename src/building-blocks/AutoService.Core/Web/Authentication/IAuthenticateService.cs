using Microsoft.AspNetCore.Identity;

namespace AutoService.Core.Web.Authentication 
{ 
    public interface IAuthenticateService
    {
        string CreateToken(Guid idUser, string email, string role);
        string ComputeSha256Hash(string password);
    }
}
