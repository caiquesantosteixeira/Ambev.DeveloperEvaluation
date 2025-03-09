using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.Application.BranchStores.CreateBranchStore
{
    public class CreateBranchStoreProfile : Profile
    {
        public CreateBranchStoreProfile()
        {
            CreateMap<CreateBranchStoreCommand, BranchStore>();
            CreateMap<BranchStore, CreateBranchStoreResult>();
        }
    }
}
