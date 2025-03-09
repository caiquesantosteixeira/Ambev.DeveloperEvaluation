using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Common.Validation;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.BranchStores.DeleteBranchStore
{
    public class DeleteBranchStoreCommand : IRequest<DeleteBranchStoreResult>
    {
        public DeleteBranchStoreCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }


        public ValidationResultDetail Validate()
        {
            var validator = new DeleteBranchStoreCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

    }
}
