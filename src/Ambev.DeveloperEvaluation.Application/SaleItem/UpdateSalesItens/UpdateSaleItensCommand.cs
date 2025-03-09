
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSalesItens;
using Ambev.DeveloperEvaluation.Common.Validation;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesItens.UpdateSalesItens
{
    public class UpdateSaleItensCommand : IRequest<UpdateSaleItensResult>
    {
        public Guid Id { get; set; }
        public Guid IdSale { get; set; }
        public Guid IdProdct { get; set; }
        public bool Canceled { get; set; }
        public decimal Quantity { get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new UpdateSaleItenCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
