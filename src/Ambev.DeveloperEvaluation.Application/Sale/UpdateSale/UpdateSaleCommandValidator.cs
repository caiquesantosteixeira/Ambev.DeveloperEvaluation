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
            RuleFor(Sale => Sale.DateVenda).GreaterThan(DateTime.MinValue);
        }
    }
}
