using AutoService.Core.Messages.Integration;
using AutoService.Payment.Domain.Enums;
using AutoService.Payment.Domain.Repositories;
using AutoService.Payment.Infrastructure.Communication;
using AutoService.Payment.Infrastructure.Communication.DTOs;
using AutoService.Payment.Infrastructure.Factory;
using EasyNetQ;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AutoService.Payment.Infrastructure.BackgroundJobs
{
    public class ProcessPaymentBackgroundService : BackgroundService
    {
        private IBus _bus;
        private readonly IServiceProvider _serviceProvider;
        
        //Test
        private const string HOST_RABBITMQ = "host=localhost:5672";
        public ProcessPaymentBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus = RabbitHutch.CreateBus(HOST_RABBITMQ);

            var sucesso = await _bus.Rpc.RespondAsync<ContractFullAcecssEvent, ResponseMessage>(async request => 
                new ResponseMessage(await ProcessPayment(request)));

            Console.WriteLine(sucesso.ToString());
        }

        private async Task<bool> ProcessPayment(ContractFullAcecssEvent request)
        {
            bool validationResult = false;

            using (var scope = _serviceProvider.CreateScope())
            {
                string customerId = string.Empty;

                ICustomerCommunicationService customerCommunicationService = scope.ServiceProvider.GetService<ICustomerCommunicationService>();
                
                var customer = await customerCommunicationService.GetCustomerByEmail(request.Email);
                
                if (customer == null)
                {
                    var resultCreateCustomer = await customerCommunicationService.CreateCustomer(new CreateCustomerRequest { name = request.NameProfessional, email = request.Email, cpfCnpj = request.Cpf });
                    customerId = resultCreateCustomer.id;
                }
                else
                {
                    customerId = customer.id;
                }

                IPaymentFactory paymentFactory = scope.ServiceProvider.GetService<IPaymentFactory>();
                
                var paymentSeviceFacade = paymentFactory.GetService((PaymentTypeEnum)request.PaymentType);
                
                var payment = new Domain.Entities.Payment(
                    Guid.Parse(request.UserId),
                    request.ValueContractFull,
                    (PaymentTypeEnum)request.PaymentType,
                    customerId);

                var transaction = await paymentSeviceFacade.AuthorizeTransaction(payment);

                if (transaction == null)
                {
                    //validationResult.Errors.Add(new ValidationFailure("Erro", ""));
                    return validationResult;
                }

                payment.AddTransaction(transaction);

                IPaymentRepository paymentRepository = scope.ServiceProvider.GetService<IPaymentRepository>();

                await paymentRepository.CreatePayment(payment);

                await paymentRepository.UnitOfWork.Commit();

                validationResult = true;
                return validationResult;
            }
        } 

    }
}
