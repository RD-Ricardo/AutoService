namespace AutoService.Payment.Infrastructure.Communication.DTOs
{
    public class CreateCustomerRequest
    {
        public string email { get; set; }
        public string name { get; set; }
        public string cpfCnpj { get; set; }
    }
}
