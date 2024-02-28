using System.Text.Json;
using AutoService.Payment.Infrastructure.Facade;
using Microsoft.Extensions.Options;
using AutoService.Payment.Infrastructure.Communication.DTOs;
using AutoService.Core.Web;
using RestSharp;

namespace AutoService.Payment.Infrastructure.Communication
{
    public class PaymentCommunicationService : IPaymentCommunicationService
    {
        private readonly PaymentConfig _paymentConfig;
        public PaymentCommunicationService(
            IOptions<PaymentConfig> paymentConfig)
        {
            _paymentConfig = paymentConfig.Value;
        }

        public async Task<RequestResult<ResponsePayment>> NewPayment(string customer, string professionalId, decimal value, string billingType)
        {
            CreatePayment payment = new()
            {
                customer = customer,
                billingType = billingType,
                value = value,
                dueDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"),
                description = "Access full",
                externalReference = professionalId,
                discount = new Discount
                {
                    value = 10,
                    dueDateLimitDays = 0
                },
                interest = new Interest
                {
                    value = 2
                },
                fine = new Fine 
                { 
                    value = 1 
                },
                postalService = false
            };

            using (var client = new RestClient(new RestClientOptions(_paymentConfig.UrlApi)))
            {
                var request = new RestRequest("/payments");

                request.AddHeader("accept", "application/json");
                request.AddHeader("access_token", _paymentConfig.DefaultApiKey);

                request.AddJsonBody(JsonSerializer.Serialize(payment));
                
                var response = await client.PostAsync(request);

                if (!response.IsSuccessStatusCode)
                    return new RequestResult<ResponsePayment>(false, null, new List<string>() { "[err] - assas" });

                var responsePayment = JsonSerializer.Deserialize<ResponsePayment>(response.Content);

                return new RequestResult<ResponsePayment>(true, responsePayment);
            }
        }
    }
}
