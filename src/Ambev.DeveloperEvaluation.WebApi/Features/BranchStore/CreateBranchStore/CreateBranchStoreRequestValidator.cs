using Ambev.DeveloperEvaluation.WebApi.Features.Store.CreateUser;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.BranchStore.CreateBranchStore;

public class CreateBranchStoreRequestValidator : AbstractValidator<CreateBranchStoreRequest>
{
    public CreateBranchStoreRequestValidator()
    {
        RuleFor(store => store.IdStore).NotEmpty().NotNull();
        RuleFor(store => store.NameBranch).NotEmpty().Length(3, 100);
    }
}