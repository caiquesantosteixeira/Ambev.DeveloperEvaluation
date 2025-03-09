using Ambev.DeveloperEvaluation.Application.Customers.CreateProduct;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<DeleteCustomerResult>
    {
        public DeleteCustomerCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }


        public ValidationResultDetail Validate()
        {
            var validator = new DeleteCustomerCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

    }
}
