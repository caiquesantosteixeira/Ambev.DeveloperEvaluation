using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Common.Validation;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    public class UpdateProductCommand : IRequest<UpdateProductResult>
    {
        public Guid Id { get; set; }
        public DateTime DateInsert { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string BarCode { get; set; } = string.Empty;
        public decimal PrecoUnitario { get; set; }
        public decimal Quantity { get; set; }
    

        public ValidationResultDetail Validate()
        {
            var validator = new UpdateProductCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

    }
}
