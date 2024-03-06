using AutoService.Core.Web.Extensions;
using AutoService.Infrastructure.Communication.CustomerService;
using AutoService.Payment.Infrastructure.Communication.DTOs;
using Microsoft.Extensions.Options;
using Moq;

namespace AutoService.Infrastructure.Tests.Communciation
{
    public class CustomerServiceTests
    {
        [Fact]
        [Trait("Categoria", "Customer communication service succes")]
        public async Task CustomerCommunicationService_Create_Succes()
        {
            // Arrage
            var customerDTO = new CreateCustomerDTO() { };
            var paymentConfig = new Mock<IOptions<PaymentSettings>>();
            var customerCommunicationService = new CustomerCommunicationService(paymentConfig.Object);

            //Act 
            var result = await customerCommunicationService.CreateCustomer(customerDTO);

            //Assert
            Assert.NotNull(result);
        }
    }
}
