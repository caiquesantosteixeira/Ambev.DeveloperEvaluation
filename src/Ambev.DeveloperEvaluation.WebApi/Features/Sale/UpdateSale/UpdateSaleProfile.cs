using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;


public class UpdateSaleProfile : Profile
{
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleRequest, UpdateSaleCommand>();
        CreateMap<UpdateSaleResult, UpdateSaleResponse>();
    }
}
