
namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItem.CreateSaleItem;

/// <summary>
/// Represents a request to create a new Branchstore in the system.
/// </summary>
public class CreateSaleItemRequest
{
    public Guid IdSale { get; set; }
    public Guid IdProdct { get; set; }
    public bool Canceled { get; set; }
    public decimal Quantity { get; set; }
}