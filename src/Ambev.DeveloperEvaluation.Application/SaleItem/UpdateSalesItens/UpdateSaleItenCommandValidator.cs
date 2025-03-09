using Ambev.DeveloperEvaluation.Application.SalesItens.UpdateSalesItens;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSalesItens
{
    public class UpdateSaleItenCommandValidator : AbstractValidator<UpdateSaleItensCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CreateUserCommandValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Email: Must be in valid format (using EmailValidator)
        /// - Username: Required, must be between 3 and 50 characters
        /// - Password: Must meet security requirements (using PasswordValidator)
        /// - Phone: Must match international format (+X XXXXXXXXXX)
        /// - Status: Cannot be set to Unknown
        /// - Role: Cannot be set to None
        /// </remarks>
        public UpdateSaleItenCommandValidator()
        {
            RuleFor(SalesItens => SalesItens.Id).NotEmpty().NotNull();
            RuleFor(SalesItens => SalesItens.Quantity).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
