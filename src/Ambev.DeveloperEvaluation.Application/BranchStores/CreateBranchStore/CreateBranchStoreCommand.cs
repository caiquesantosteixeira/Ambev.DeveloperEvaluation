using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Common.Validation;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.BranchStores.CreateBranchStore
{
    public class CreateBranchStoreCommand : IRequest<CreateBranchStoreResult>
    {
        public string NameBranch { get; set; } = string.Empty;
        public Guid IdStore { get; set; }


        public ValidationResultDetail Validate()
        {
            var validator = new CreateBranchStoreCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

    }
}
