using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(user => user.Id).NotEmpty().NotNull();
            RuleFor(user => user.Name).NotEmpty().Length(3, 100);
            RuleFor(user => user.Description).NotEmpty().Length(3, 250);
            RuleFor(user => user.BarCode).Length(0, 20);
            RuleFor(user => user.PrecoUnitario).GreaterThan(0);
            RuleFor(user => user.Quantity).GreaterThan(0);
        }
    }
}
