using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.BranchStores.UpdateBranchStore
{
    public class UpdateBranchStoreCommandValidator : AbstractValidator<UpdateBranchStoreCommand>
    {
        public UpdateBranchStoreCommandValidator()
        {
            RuleFor(BranchStore => BranchStore.Id).NotEmpty().NotNull();
            RuleFor(BranchStore => BranchStore.IdStore).NotEmpty().NotNull();
            RuleFor(BranchStore => BranchStore.NameBranch).NotEmpty().Length(3, 100);
        }
    }
}
