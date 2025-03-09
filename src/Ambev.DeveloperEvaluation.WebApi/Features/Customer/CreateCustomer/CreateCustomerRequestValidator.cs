using Ambev.DeveloperEvaluation.WebApi.Features.Store.CreateUser;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customer.CreateCustomer;

public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerRequestValidator()
    {
        RuleFor(customer => customer.Name).NotEmpty().Length(3, 100);
        RuleFor(customer => customer.Email).NotEmpty().Length(3, 100);
        RuleFor(customer => customer.PhoneNumber).NotEmpty().Length(0, 20);
        RuleFor(customer => customer.Address).NotEmpty().Length(3, 100);
    }
}