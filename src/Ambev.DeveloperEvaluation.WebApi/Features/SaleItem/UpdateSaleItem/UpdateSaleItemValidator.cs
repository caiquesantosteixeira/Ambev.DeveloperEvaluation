using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItem.CreateSaleItem;

public class UpdateSaleItemValidator : AbstractValidator<UpdateSaleItemRequest>
{
    public UpdateSaleItemValidator()
    {
        RuleFor(Sale => Sale.Quantity).NotEmpty().NotNull().GreaterThan(0);
    }
}