using FluentValidation.Results;

namespace AutoService.Core.Messages.Integration
{
    public class ResponseMessage : Message
    {
        public bool ValidationResult  { get; set; }
        public ResponseMessage(bool validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}
