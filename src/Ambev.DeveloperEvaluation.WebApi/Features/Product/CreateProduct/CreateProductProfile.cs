using Ambev.DeveloperEvaluation.Application.BranchStores.CreateBranchStore;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProduct;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProductr;


public class CreateProductProfile : Profile
{
    public CreateProductProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>();
        CreateMap<CreateProductResult, CreateProductResponse>();
    }
}
