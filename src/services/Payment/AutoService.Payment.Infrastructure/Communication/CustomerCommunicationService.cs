using AutoService.Payment.Infrastructure.Communication.DTOs;
using AutoService.Payment.Infrastructure.Facade;
using Microsoft.Extensions.Options;
using RestSharp;
using System.Text.Json;

namespace AutoService.Payment.Infrastructure.Communication
{
    public class CustomerCommunicationService : ICustomerCommunicationService
    {
        private readonly PaymentConfig _paymentConfig;
        public CustomerCommunicationService(IOptions<PaymentConfig> paymentConfig)
        {
            _paymentConfig = paymentConfig.Value;
        }

        public async Task<CustomerDTO> CreateCustomer(CreateCustomerRequest customer)
        {
            using (var client = new RestClient(new RestClientOptions(_paymentConfig.UrlApi)))
            {
                var request = new RestRequest("/customers");

                request.AddHeader("accept", "application/json");
                request.AddHeader("access_token", _paymentConfig.DefaultApiKey);

                var json = JsonSerializer.Serialize(customer);

                request.AddJsonBody(json);

                var response = await client.PostAsync(request);

                return JsonSerializer.Deserialize<CustomerDTO>(response.Content);
            } 
        }

        public async Task<CustomerDTO> GetCustomerByEmail(string email)
        {
            using (var client = new RestClient(new RestClientOptions(_paymentConfig.UrlApi)))
                {
                var request = new RestRequest($"/customers?email={email}");

                request.AddHeader("accept", "application/json");
                request.AddHeader("access_token", _paymentConfig.DefaultApiKey);

                var response = await client.GetAsync(request);

                if (!response.IsSuccessStatusCode)
                    return null;

                var content =  JsonSerializer.Deserialize<ResponseCustomer>(response.Content);

                return content.data.FirstOrDefault();
            }
        }
    }
}
