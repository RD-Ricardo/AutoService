using AutoService.Core.Abstractions.CQRS;
using FluentValidation;
using MediatR;

namespace AutoService.Application.Commands.Service.CreateService
{
    public class CreateServiceCommand(string name, string description, decimal value, string professionalId) : Command<Unit>
    {
        public string Name { get; private set; } = name;
        public string Description { get; private set; } = description;
        public decimal Value { get; private set; } = value;
        public Guid ProfessionalId { get; private set; } = Guid.Parse(professionalId);

        public override bool Validate()
        {
            ValidationResult = new CreateServiceCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }

        private class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
        {
            public CreateServiceCommandValidator()
            {
                RuleFor(c => c.Name)
                    .NotEmpty()
                    .NotNull();

                RuleFor(c => c.Description)
                   .NotEmpty()
                   .NotNull();

                RuleFor(c => c.Value)
                  .NotEmpty()
                  .NotNull()
                  .NotEqual(0);
            }
        }
    }

}
