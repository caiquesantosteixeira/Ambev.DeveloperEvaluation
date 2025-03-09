using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.Application.Stores.CreateStore
{
    public class CreateStoreProfile : Profile
    {
        public CreateStoreProfile()
        {
            CreateMap<CreateStoreCommand, Store>();
            CreateMap< Store, CreateStoreResult>();
        }
    }
}
