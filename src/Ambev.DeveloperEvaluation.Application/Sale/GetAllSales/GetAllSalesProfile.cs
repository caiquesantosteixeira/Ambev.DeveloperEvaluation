using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.SalesItem;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

/// <summary>
/// Profile for mapping between User entity and GetUserResponse
/// </summary>
public class GetAllSalesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser operation
    /// </summary>
    public GetAllSalesProfile()
    {
        CreateMap<Sale, SaleResultDto>();
    }
}
