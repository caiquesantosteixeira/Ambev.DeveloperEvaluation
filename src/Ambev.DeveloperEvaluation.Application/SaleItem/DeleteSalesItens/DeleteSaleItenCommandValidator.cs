using Ambev.DeveloperEvaluation.Application.SalesItens.DeleteSalesItens;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSalesItens
{
    public class DeleteSaleItenCommandValidator : AbstractValidator<DeleteSaleItensCommand>
    {

        public DeleteSaleItenCommandValidator()
        {
            RuleFor(SalesItens => SalesItens.Id).NotEmpty().NotNull();
        }
    }
}
