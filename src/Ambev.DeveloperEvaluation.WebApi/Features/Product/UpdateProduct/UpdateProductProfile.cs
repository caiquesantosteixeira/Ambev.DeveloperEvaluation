using Ambev.DeveloperEvaluation.Application.BranchStores.CreateBranchStore;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProduct;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProductr;


public class UpdateProductProfile : Profile
{
    public UpdateProductProfile()
    {
        CreateMap<UpdateProductRequest, UpdateProductCommand>();
        CreateMap<UpdateProductResult, UpdateProductResponse>();
    }
}
