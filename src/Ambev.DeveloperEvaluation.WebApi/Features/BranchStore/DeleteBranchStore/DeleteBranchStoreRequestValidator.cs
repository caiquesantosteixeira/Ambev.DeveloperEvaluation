using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.BranchStore.DeleteBranchStore;

/// <summary>
/// Validator for DeleteUserRequest
/// </summary>
public class DeleteBranchStoreRequestValidator : AbstractValidator<DeleteBranchStoreRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteUserRequest
    /// </summary>
    public DeleteBranchStoreRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
