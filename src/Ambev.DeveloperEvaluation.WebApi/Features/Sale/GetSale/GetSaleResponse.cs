using Ambev.DeveloperEvaluation.Application.SalesItem;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;

public class GetSaleResponse
{
    public DateTime DateVenda { get; set; }
    public decimal Total { get; set; }
    public bool Canceled { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string BrancheStoreName { get; set; } = string.Empty;

    public List<SaleItemDto> SalesItems = [];
}
