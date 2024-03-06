using AutoService.Application.Commands.Professional.CreateProfessional;
using AutoService.Core.Web;
using AutoService.Domain.Interfaces;
using MediatR;
using Moq;
using Moq.AutoMock;

namespace AutoService.Application.Tests.Commands.Professional
{
    public class CreateProfessionalCommandHandlerTests
    {

        [Fact(DisplayName = "Adicionar professional")]
        [Trait("Categoria", "Professional - Create")]
        public async Task CreateProfessional_New_Sucecs()
        {
            //Arrage
            var command = new CreateProfessionalCommand("Ricardo", "teste", "teste", "dsads", "Ricardo");
            var mocker = new AutoMocker();
            var commandHandler = mocker.CreateInstance<CreateProfessionalCommandHandler>();

            //Act
            var result = await commandHandler.Handle(command, CancellationToken.None);

            //Assert
            var resultValid = new RequestResult<Unit>(success: true);
            Assert.Equal(resultValid, result);
            mocker.GetMock<IProfessionalRepository>().Verify(r => r.CreateAsync(It.IsAny<Domain.Entities.Professional>()), Times.Once);
        }
    }
}
