﻿using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleCommandValidator()
        {
            RuleFor(Sale => Sale.IdBranchStore).NotEmpty().NotNull();
            RuleFor(Sale => Sale.IdCustomer).NotEmpty().NotNull();
            RuleFor(Sale => Sale.DateVenda).GreaterThan(DateTime.MinValue);
        }
    }
}
