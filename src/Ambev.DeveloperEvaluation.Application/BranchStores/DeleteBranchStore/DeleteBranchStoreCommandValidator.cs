using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.BranchStores.DeleteBranchStore
{
    public class DeleteBranchStoreCommandValidator : AbstractValidator<DeleteBranchStoreCommand>
    {
        public DeleteBranchStoreCommandValidator()
        {
            RuleFor(BranchStore => BranchStore.Id).NotEmpty().NotNull();
        }
    }
}
