using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.BranchStores.UpdateBranchStore
{
    public class UpdateBranchStoreHandler : IRequestHandler<UpdateBranchStoreCommand, UpdateBranchStoreResult>
    {
        private readonly IBranchStoreRepository _branchStoreRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public UpdateBranchStoreHandler(IBranchStoreRepository branchStoreRepository, IStoreRepository storeRepository,  IMapper mapper)
        {
            _branchStoreRepository = branchStoreRepository;
            _storeRepository = storeRepository;
            _mapper = mapper;
        }
        public async Task<UpdateBranchStoreResult> Handle(UpdateBranchStoreCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateBranchStoreCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingBranchStore = _branchStoreRepository.GetById(command.Id);

            if (existingBranchStore == null)
                throw new InvalidOperationException($"BranchStore with Name {command.NameBranch} not exists");

            var existingStore = _storeRepository.GetById(command.IdStore);

            if (existingStore == null)
                throw new InvalidOperationException($"Store with Id {existingBranchStore.IdStore} not exists");


            var branchStore = _mapper.Map<BranchStore>(command);
            var createdBranchStore = _branchStoreRepository.Update(branchStore);
            _branchStoreRepository.SaveChanges();
            var result = _mapper.Map<UpdateBranchStoreResult>(createdBranchStore);
            return result;
        }
    }
}
