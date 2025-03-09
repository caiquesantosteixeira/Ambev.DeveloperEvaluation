
namespace Ambev.DeveloperEvaluation.WebApi.Features.BranchStore.UpdateBranchStore;

/// <summary>
/// Represents a request to update a store in the system.
/// </summary>
public class UpdateBranchStoreRequest
{
    /// <summary>
    /// Gets or sets the Id.
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Gets or sets the NameStore.
    /// </summary>
    public string NameStore { get; set; } = string.Empty;
}