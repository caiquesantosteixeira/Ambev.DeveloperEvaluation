using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItem.CreateSaleItem;

public class DeleteSalteItemRequestValidator : AbstractValidator<DeleteSaleItemRequest>
{
    public DeleteSalteItemRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
