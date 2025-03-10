namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetSale
{
    public class SaleItemDto
    {
        public Guid IdSale { get; set; }
        public Guid IdProdct { get; set; }
        public bool Canceled { get; set; }
        public decimal Quantity { get; set; }
        public string ProductName { get; set; } = string.Empty;
    }
}
