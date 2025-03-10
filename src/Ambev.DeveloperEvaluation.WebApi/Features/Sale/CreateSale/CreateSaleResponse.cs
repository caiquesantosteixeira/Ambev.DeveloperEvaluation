namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

/// <summary>
/// API response model for CreateStore operation
/// </summary>
public class CreateSaleResponse
{
    public Guid Id { get; set; }
    public DateTime DateVenda { get; set; }
    public decimal Total { get; set; }
    public bool Canceled { get; set; }
    public bool Finalized { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string BrancheStoreName { get; set; } = string.Empty;
    public Guid IdBranchStore { get; set; }
    public Guid IdCustomer { get; set; }
}
