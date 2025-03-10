using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;

/// <summary>
/// Profile for mapping GetUser feature requests to commands
/// </summary>
public class GetSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser feature
    /// </summary>
    public GetSaleProfile()
    {
        CreateMap<Guid,GetSaleCommand>().ConstructUsing(id => new GetSaleCommand(id));
        CreateMap<GetSaleResult, GetSaleResponse>();
    }
}
