using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;


public record GetAllSalesCommand : IRequest<List<SaleResultDto>>
{

}
