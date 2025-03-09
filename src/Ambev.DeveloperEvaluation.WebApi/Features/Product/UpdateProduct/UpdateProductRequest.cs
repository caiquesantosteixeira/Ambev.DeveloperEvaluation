
namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProduct;

/// <summary>
/// Represents a request to create a new Branchstore in the system.
/// </summary>
public class UpdateProductRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string BarCode { get; set; } = string.Empty;
    public decimal PrecoUnitario { get; set; }
    public decimal Quantity { get; set; }
    public bool Active { get; set; }
}