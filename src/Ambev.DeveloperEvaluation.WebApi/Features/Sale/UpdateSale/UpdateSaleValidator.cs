using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

public class UpdateSaleValidator : AbstractValidator<UpdateSaleRequest>
{
    public UpdateSaleValidator()
    {
        RuleFor(customer => customer.Id).NotEmpty().NotNull();
        RuleFor(Sale => Sale.IdBranchStore).NotEmpty().NotNull();
        RuleFor(Sale => Sale.IdCustomer).NotEmpty().NotNull();
        RuleFor(Sale => Sale.DateVenda).LessThan(DateTime.Now);
    }
}