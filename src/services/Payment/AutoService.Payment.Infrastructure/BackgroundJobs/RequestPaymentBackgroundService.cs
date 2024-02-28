using AutoService.Core.Messages.Integration;
using AutoService.Payment.Domain.Enums;
using AutoService.Payment.Domain.Repositories;
using AutoService.Payment.Infrastructure.Communication;
using AutoService.Payment.Infrastructure.Factory;
using EasyNetQ;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AutoService.Payment.Infrastructure.BackgroundJobs
{
    public class RequestPaymentBackgroundService : BackgroundService
    {
        private IBus _bus;
        private readonly IServiceProvider _serviceProvider;
        public RequestPaymentBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus = RabbitHutch.CreateBus("host=localhost:5672");

            var success = _bus.Rpc.RespondAsync<ContractFullAcecssEvent, ResponseMessage>(async request => 
                new ResponseMessage(await ProcessPayment(request)));

            return Task.CompletedTask;
        }

        private async Task<ValidationResult> ProcessPayment(ContractFullAcecssEvent request)
        {
            var validationResult = new ValidationResult();

            using (var scope = _serviceProvider.CreateScope())
            {
                ICustomerCommunicationService customerCommunicationService = scope.ServiceProvider.GetService<ICustomerCommunicationService>();
                
                var customer = await customerCommunicationService.GetCustomerByEmail(request.Email);
                
                if (customer == null)
                {
                    validationResult.Errors.Add(new ValidationFailure("Erro", ""));
                    return validationResult;
                }

                IPaymentFactory paymentFactory = scope.ServiceProvider.GetService<IPaymentFactory>();
                
                var paymentSeviceFacade = paymentFactory.GetService((PaymentTypeEnum)request.PaymentType);
                
                var payment = new Domain.Entities.Payment(
                    Guid.Parse(request.UserId),
                    request.ValueContractFull,
                    (PaymentTypeEnum)request.PaymentType,
                    customer.id);

                var transaction = await paymentSeviceFacade.AuthorizeTransaction(payment);

                if (transaction == null)
                {
                    validationResult.Errors.Add(new ValidationFailure("Erro", ""));
                    return validationResult;
                }

                payment.AddTransaction(transaction);

                IPaymentRepository paymentRepository = scope.ServiceProvider.GetService<IPaymentRepository>();

                await paymentRepository.CreatePayment(payment);

                return validationResult;
            }
        } 

    }
}
