using Ambev.DeveloperEvaluation.Application.SalesItens.CreateSalesItens;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSalesItens
{
    public class CreateSaleItenCommandValidator : AbstractValidator<CreateSaleItensCommand>
    {
        public CreateSaleItenCommandValidator()
        {
            RuleFor(Sale => Sale.Quantity).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
