
namespace Ambev.DeveloperEvaluation.WebApi.Features.BranchStore.CreateBranchStore;

/// <summary>
/// Represents a request to create a new Branchstore in the system.
/// </summary>
public class CreateBranchStoreRequest
{
    public string NameBranch { get; set; } = string.Empty;
    public Guid IdStore { get; set; }
}