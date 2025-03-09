using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Store.CreateStore;

/// <summary>
/// API response model for CreateStore operation
/// </summary>
public class CreateStoreResponse
{
    /// <summary>
    /// The unique identifier of the created Store
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Gets or sets the NameStore.
    /// </summary>
    public string NameStore { get; set; } = string.Empty;
}
