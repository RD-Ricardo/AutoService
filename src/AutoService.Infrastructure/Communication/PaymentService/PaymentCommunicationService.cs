using System.Text.Json;
using Microsoft.Extensions.Options;
using AutoService.Core.Web;
using RestSharp;
using AutoService.Core.Web.Extensions;
using AutoService.Payment.Infrastructure.Communication.DTOs;
using AutoService.Infrastructure.Communication.DTOs;

namespace AutoService.Infrastructure.Communication.PaymentService
{
    public class PaymentCommunicationService : IPaymentCommunicationService
    {
        private readonly PaymentSettings _paymentConfig;
        public PaymentCommunicationService(
            IOptions<PaymentSettings> paymentConfig)
        {
            _paymentConfig = paymentConfig.Value;
        }

        public async Task<RequestResult<ResponsePaymentDTO>> NewPayment(string customer, string professionalId, decimal value, string billingType)
        {
            CreatePaymentDTO payment = new()
            {
                customer = customer,
                billingType = billingType,
                value = value,
                dueDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"),
                description = "Access full",
                externalReference = professionalId,
                discount = new DiscountDTO
                {
                    Value = 10,
                    DueDateLimitDays = 0
                },
                interest = new InterestDTO
                {
                    Value = 2
                },
                fine = new FineDTO
                {
                    Value = 1
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
                    return new RequestResult<ResponsePaymentDTO>(false, null, new List<string>() { "[err] - assas" });

                
                return new RequestResult<ResponsePaymentDTO>(true, JsonSerializer.Deserialize<ResponsePaymentDTO>(response.Content));
            }
        }
    }
}
