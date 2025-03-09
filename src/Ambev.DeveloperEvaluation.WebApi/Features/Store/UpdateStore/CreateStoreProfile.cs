using Ambev.DeveloperEvaluation.Application.Stores.CreateStore;
using Ambev.DeveloperEvaluation.Application.Stores.UpdateStore;
using Ambev.DeveloperEvaluation.WebApi.Features.Store.CreateUser;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Store.UpdateStore;


public class UpdateStoreProfile : Profile
{
    public UpdateStoreProfile()
    {
        CreateMap<UpdateStoreRequest, UpdateStoreCommand>();
        CreateMap<UpdateStoreResult, UpdateStoreResponse>();
    }
}
