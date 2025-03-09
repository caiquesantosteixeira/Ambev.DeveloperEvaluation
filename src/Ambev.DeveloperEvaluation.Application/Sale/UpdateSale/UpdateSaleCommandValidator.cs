using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleCommand>
    {
        public UpdateSaleCommandValidator()
        {
            RuleFor(Sale => Sale.Id).NotEmpty().NotNull();
            RuleFor(Sale => Sale.IdBranchStore).NotEmpty().NotNull();
            RuleFor(Sale => Sale.IdCustomer).NotEmpty().NotNull();
            RuleFor(Sale => Sale.DateVenda).LessThan(DateTime.Now).GreaterThan(DateTime.MinValue);
        }
    }
}
