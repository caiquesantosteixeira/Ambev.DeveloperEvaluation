using Ambev.DeveloperEvaluation.Application.BranchStores.UpdateBranchStore;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.WebApi.Features.BranchStore.UpdateBranchStore;


public class UpdateBranchStoreProfile : Profile
{
    public UpdateBranchStoreProfile()
    {
        CreateMap<UpdateBranchStoreRequest, UpdateBranchStoreCommand>();
        CreateMap<UpdateBranchStoreResult, UpdateBranchStoreResponse>();
    }
}
