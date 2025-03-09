using Ambev.DeveloperEvaluation.WebApi.Features.Store.UpdateStore;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Store.UpdateStore;

public class UpdateStoreRequestValidator : AbstractValidator<UpdateStoreRequest>
{
    public UpdateStoreRequestValidator()
    {
        RuleFor(store => store.Id).NotEmpty().NotNull();
        RuleFor(store => store.NameStore).NotEmpty().Length(3, 100);
    }
}