
namespace Ambev.DeveloperEvaluation.WebApi.Features.Store.UpdateStore;

/// <summary>
/// Represents a request to update a store in the system.
/// </summary>
public class UpdateStoreRequest
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