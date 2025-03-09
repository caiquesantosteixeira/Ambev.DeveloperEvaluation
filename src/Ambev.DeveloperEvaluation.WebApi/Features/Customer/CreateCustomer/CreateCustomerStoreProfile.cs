using Ambev.DeveloperEvaluation.Application.BranchStores.CreateBranchStore;
using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Customer.CreateCustomer;


public class CreateCustomerStoreProfile : Profile
{
    public CreateCustomerStoreProfile()
    {
        CreateMap<CreateCustomerRequest, CreateCustomerCommand>();
        CreateMap<CreateBranchStoreResult, CreateCustomerResponse>();
    }
}
