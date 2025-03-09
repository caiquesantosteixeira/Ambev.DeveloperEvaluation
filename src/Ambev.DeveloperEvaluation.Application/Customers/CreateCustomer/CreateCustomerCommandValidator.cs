using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateProduct
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(customer => customer.Name).NotEmpty().Length(3, 100);
            RuleFor(customer => customer.Email).NotEmpty().Length(3, 100);
            RuleFor(customer => customer.PhoneNumber).NotEmpty().Length(0, 20);
            RuleFor(customer => customer.Address).NotEmpty().Length(3, 100);
        }
    }
}
