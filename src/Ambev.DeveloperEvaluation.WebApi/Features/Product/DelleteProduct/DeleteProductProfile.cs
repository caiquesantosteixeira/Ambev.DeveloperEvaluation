using Ambev.DeveloperEvaluation.Application.BranchStores.DeleteBranchStore;
using Ambev.DeveloperEvaluation.Application.Customers.DeleteCustomer;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.DeleteProduct;

public class DeleteProductProfile : Profile
{
    public DeleteProductProfile()
    {
        CreateMap<Guid, DeleteProductCommand>()
            .ConstructUsing(id => new DeleteProductCommand(id));
    }
}
