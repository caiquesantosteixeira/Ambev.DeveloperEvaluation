using Ambev.DeveloperEvaluation.WebApi.Features.Store.UpdateStore;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.BranchStore.UpdateBranchStore;

public class UpdateBranchStoreRequestValidator : AbstractValidator<UpdateBranchStoreRequest>
{
    public UpdateBranchStoreRequestValidator()
    {
        RuleFor(store => store.Id).NotEmpty().NotNull();
        RuleFor(store => store.NameStore).NotEmpty().Length(3, 100);
    }
}