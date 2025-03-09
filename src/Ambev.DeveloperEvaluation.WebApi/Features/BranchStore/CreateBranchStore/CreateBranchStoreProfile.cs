using Ambev.DeveloperEvaluation.Application.BranchStores.CreateBranchStore;
using Ambev.DeveloperEvaluation.Application.Stores.CreateStore;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.WebApi.Features.BranchStore.CreateBranchStore;


public class CreateBranchStoreProfile : Profile
{
    public CreateBranchStoreProfile()
    {
        CreateMap<CreateBranchStoreRequest, CreateBranchStoreCommand>();
        CreateMap<CreateBranchStoreResult, CreateBranchStoreResponse>();
    }
}
