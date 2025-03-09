using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.Application.BranchStores.UpdateBranchStore
{
    public class UpdateBranchStoreProfile : Profile
    {
        public UpdateBranchStoreProfile()
        {
            CreateMap<UpdateBranchStoreCommand, BranchStore>();
            CreateMap<BranchStore, UpdateBranchStoreResult>();
        }
    }
}
