
using Ambev.DeveloperEvaluation.Application.Sales.CreateSalesItens;
using Ambev.DeveloperEvaluation.Application.SalesItens.CreateSalesItens;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItem.CreateSaleItem;


public class CreateSaleItemStoreProfile : Profile
{
    public CreateSaleItemStoreProfile()
    {
        CreateMap<CreateSaleItemRequest, CreateSaleItensCommand>();
        CreateMap<CreateSaleItenResult, CreateSaleItemResponse>();
    }
}
