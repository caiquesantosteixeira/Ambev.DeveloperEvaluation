using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItem.CreateSaleItem;

/// <summary>
/// API response model for CreateStore operation
/// </summary>
public class CreateSaleItemResponse
{
    public Guid IdSale { get; set; }
    public Guid IdProdct { get; set; }
    public int PercentualDescount { get; set; }
    public bool Canceled { get; set; }
    public decimal Quantity { get; set; }
}
