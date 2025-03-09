using Ambev.DeveloperEvaluation.Application.BranchStores.CreateBranchStore;
using Ambev.DeveloperEvaluation.Application.BranchStores.UpdateBranchStore;
using Ambev.DeveloperEvaluation.Application.Customers.UpdateCustomer;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Customer.UpdateCustomer;


public class UpdateCustomerProfile : Profile
{
    public UpdateCustomerProfile()
    {
        CreateMap<UpdateCustomerRequest, UpdateCustomerCommand>();
        CreateMap<UpdateCustomerResult, UpdateCustomerResponse>();
    }
}
