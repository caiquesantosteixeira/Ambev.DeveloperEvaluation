using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProduct;

/// <summary>
/// API response model for CreateStore operation
/// </summary>
public class UpdateProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string BarCode { get; set; } = string.Empty;
    public decimal PrecoUnitario { get; set; }
    public decimal Quantity { get; set; }
    public bool Active { get; set; }
}
