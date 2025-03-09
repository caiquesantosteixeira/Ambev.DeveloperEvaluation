using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Stores.UpdateStore
{
    public class UpdateStoreCommand : IRequest<UpdateStoreResult>
    {
        public Guid Id { get; set; }    
        public string NameStore { get; set; } = string.Empty;


        public ValidationResultDetail Validate()
        {
            var validator = new UpdateStoreCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
