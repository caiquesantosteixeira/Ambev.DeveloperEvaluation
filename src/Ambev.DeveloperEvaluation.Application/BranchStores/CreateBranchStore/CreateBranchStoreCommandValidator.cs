using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.BranchStores.CreateBranchStore
{
    public class CreateBranchStoreCommandValidator : AbstractValidator<CreateBranchStoreCommand>
    {
        public CreateBranchStoreCommandValidator()
        {
            RuleFor(BranchStore => BranchStore.NameBranch).NotEmpty().Length(3, 100);
            RuleFor(BranchStore => BranchStore.IdStore).NotEmpty().NotNull();
        }
    }
}
