
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSalesItens;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesItens.DeleteSalesItens
{
    public class DeleteSaleItensCommand : IRequest<DeleteSaleItensResult>
    {
        public Guid Id { get; set; }
       

        public ValidationResultDetail Validate()
        {
            var validator = new DeleteSaleItenCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
