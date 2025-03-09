using Ambev.DeveloperEvaluation.Application.Stores.CreateStore;
using Ambev.DeveloperEvaluation.WebApi.Features.Store.CreateUser;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Store.CreateStore;


public class CreateStoreProfile : Profile
{
    public CreateStoreProfile()
    {
        CreateMap<CreateStoreRequest, CreateStoreCommand>();
        CreateMap<CreateStoreResult, CreateStoreResponse>();
    }
}
