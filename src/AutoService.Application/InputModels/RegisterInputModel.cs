namespace AutoService.Application.InputModels
{
    public record RegisterInputModel(string Email, string Password, string PasswordConfirmed, string CPF, string Name);
    
}
