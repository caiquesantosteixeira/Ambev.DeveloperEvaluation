using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(customer => customer.Id).NotEmpty().NotNull();
            RuleFor(customer => customer.Name).NotEmpty().NotNull().Length(3, 100);
            RuleFor(customer => customer.Email).NotEmpty().NotNull().Length(3, 100);
            RuleFor(customer => customer.PhoneNumber).NotEmpty().NotNull().Length(0, 20);
            RuleFor(customer => customer.Address).NotEmpty().NotNull().Length(3, 100);
        }
    }
}
