using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleRequestValidator()
    {
        RuleFor(Sale => Sale.IdBranchStore).NotEmpty().NotNull();
        RuleFor(Sale => Sale.IdCustomer).NotEmpty().NotNull();
        RuleFor(Sale => Sale.DateVenda).LessThan(DateTime.Now).GreaterThan(DateTime.MinValue);
    }
}