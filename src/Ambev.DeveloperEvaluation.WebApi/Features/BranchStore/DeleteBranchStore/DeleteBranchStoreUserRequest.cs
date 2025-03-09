namespace Ambev.DeveloperEvaluation.WebApi.Features.BranchStore.DeleteBranchStore;

/// <summary>
/// Request model for deleting a user
/// </summary>
public class DeleteBranchStoreRequest
{
    /// <summary>
    /// The unique identifier of the user to delete
    /// </summary>
    public Guid Id { get; set; }
}
