using Ambev.DeveloperEvaluation.Application.BranchStores.DeleteBranchStore;
using Ambev.DeveloperEvaluation.Application.Customers.DeleteCustomer;
using Ambev.DeveloperEvaluation.Application.SalesItens.DeleteSalesItens;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItem.CreateSaleItem;

public class DeleteSaleItemProfile : Profile
{
    public DeleteSaleItemProfile()
    {
        CreateMap<Guid, DeleteSaleItensCommand>()
            .ConstructUsing(id => new DeleteSaleItensCommand(id));
    }
}
