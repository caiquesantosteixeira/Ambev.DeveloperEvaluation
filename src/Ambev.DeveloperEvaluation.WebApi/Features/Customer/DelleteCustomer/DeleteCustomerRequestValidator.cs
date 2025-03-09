using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customer.DeleteCustomer;

public class DeleteCustomerRequestValidator : AbstractValidator<DeleteCustomerRequest>
{
    public DeleteCustomerRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
