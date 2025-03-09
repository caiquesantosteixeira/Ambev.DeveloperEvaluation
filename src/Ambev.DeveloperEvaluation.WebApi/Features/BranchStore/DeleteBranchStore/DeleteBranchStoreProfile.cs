using Ambev.DeveloperEvaluation.Application.BranchStores.DeleteBranchStore;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.BranchStore.DeleteBranchStore;

/// <summary>
/// Profile for mapping DeleteBranchStore feature requests to commands
/// </summary>
public class DeleteBranchStoreProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteBranchStore feature
    /// </summary>
    public DeleteBranchStoreProfile()
    {
        CreateMap<Guid, DeleteBranchStoreCommand>()
            .ConstructUsing(id => new DeleteBranchStoreCommand(id));
    }
}
