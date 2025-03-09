using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.Application.Stores.UpdateStore
{
    public class UpdateStoreProfile : Profile
    {
        public UpdateStoreProfile()
        {
            CreateMap<UpdateStoreCommand, Store>();
            CreateMap< Store, UpdateStoreResult>();
        }
    }
}
