using Ambev.DeveloperEvaluation.WebApi.Features.Store.CreateUser;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProduct;

public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductRequestValidator()
    {
        RuleFor(prod => prod.Id).NotEmpty().NotNull();
        RuleFor(prod => prod.Name).NotEmpty().Length(3, 100); ;
        RuleFor(prod => prod.Description).NotEmpty().Length(3, 250);
        RuleFor(prod => prod.BarCode).Length(0, 20);
        RuleFor(prod => prod.PrecoUnitario).GreaterThan(0);
        RuleFor(prod => prod.Quantity).GreaterThan(0);
    }
}