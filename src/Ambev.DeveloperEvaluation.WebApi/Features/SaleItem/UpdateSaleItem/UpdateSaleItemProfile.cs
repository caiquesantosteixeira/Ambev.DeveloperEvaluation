using Ambev.DeveloperEvaluation.Application.Sales.UpdateSalesItens;
using Ambev.DeveloperEvaluation.Application.SalesItens.UpdateSalesItens;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItem.CreateSaleItem;


public class UpdateSaleItemProfile : Profile
{
    public UpdateSaleItemProfile()
    {
        CreateMap<UpdateSaleItemRequest, UpdateSaleItensCommand>();
        CreateMap<UpdateSaleItensResult, UpdateSaleItemResponse>();
    }
}
