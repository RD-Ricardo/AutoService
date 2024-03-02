namespace AutoService.Payment.Infrastructure.Communication.DTOs
{
    public class CreateCustomerDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string CpfCnpj { get; set; }
    }
}
