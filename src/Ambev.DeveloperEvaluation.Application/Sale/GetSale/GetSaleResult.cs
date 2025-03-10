using Ambev.DeveloperEvaluation.Application.SalesItem;


namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleResult
{
    public DateTime DateVenda { get; set; }
    public decimal Total { get; set; }
    public bool Canceled { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string BrancheStoreName { get; set; } = string.Empty;

    public List<SaleItemDto> SalesItems = [];
}
