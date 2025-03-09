
using Ambev.DeveloperEvaluation.Application.Sales.CreateSalesItens;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.SalesItens.CreateSalesItens
{
    public class CreateSaleItensCommand : IRequest<CreateSaleItenResult>
    {
        public Guid IdSale { get; set; }
        public Guid IdProdct { get; set; }
        public bool Canceled { get; set; }
        public decimal Quantity { get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new CreateSaleItenCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
