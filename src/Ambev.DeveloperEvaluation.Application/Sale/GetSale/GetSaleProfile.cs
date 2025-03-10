using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.SalesItem;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Profile for mapping between User entity and GetUserResponse
/// </summary>
public class GetSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser operation
    /// </summary>
    public GetSaleProfile()
    {
        CreateMap<Sale, GetSaleResult>();

        CreateMap<SaleItem, SaleItemDto>();

    }
}
