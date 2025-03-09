using Ambev.DeveloperEvaluation.WebApi.Features.Store.CreateUser;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customer.UpdateCustomer;

public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerRequest>
{
    public UpdateCustomerValidator()
    {
        RuleFor(customer => customer.Id).NotEmpty().NotNull();
        RuleFor(customer => customer.Name).NotEmpty().Length(3, 100);
        RuleFor(customer => customer.Email).NotEmpty().Length(3, 100);
        RuleFor(customer => customer.PhoneNumber).NotEmpty().Length(0, 20);
        RuleFor(customer => customer.Address).NotEmpty().Length(3, 100);
    }
}