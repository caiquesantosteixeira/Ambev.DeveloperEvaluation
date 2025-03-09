using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.BranchStore.CreateBranchStore;

/// <summary>
/// API response model for CreateStore operation
/// </summary>
public class CreateBranchStoreResponse
{
    public Guid Id { get; set; }
    public string NameBranch { get; set; } = string.Empty;
    public Guid IdStore { get; set; }
}
