
namespace Ambev.DeveloperEvaluation.WebApi.Features.Store.CreateUser;

/// <summary>
/// Represents a request to create a new store in the system.
/// </summary>
public class CreateStoreRequest
{
    /// <summary>
    /// Gets or sets the NameStore.
    /// </summary>
    public string NameStore { get; set; } = string.Empty;
}