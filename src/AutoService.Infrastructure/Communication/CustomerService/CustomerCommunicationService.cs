using AutoService.Core.Web.Extensions;
using AutoService.Infrastructure.Communication.DTOs;
using AutoService.Payment.Infrastructure.Communication.DTOs;
using Microsoft.Extensions.Options;
using RestSharp;
using System.Text.Json;

namespace AutoService.Infrastructure.Communication.CustomerService
{
    public class CustomerCommunicationService : ICustomerCommunicationService
    {
        private readonly PaymentSettings _paymentConfig;
        public CustomerCommunicationService(IOptions<PaymentSettings> paymentConfig)
        {
            _paymentConfig = paymentConfig.Value;
        }

        public async Task<CustomerDTO> CreateCustomer(CreateCustomerDTO customer)
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

                var content = JsonSerializer.Deserialize<ResponseCustomerDTO>(response.Content);

                return content.Data.FirstOrDefault();
            }
        }
    }
}
