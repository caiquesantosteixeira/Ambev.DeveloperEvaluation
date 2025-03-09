using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.BranchStores.CreateBranchStore
{
    public class CreateBranchStoreHandler : IRequestHandler<CreateBranchStoreCommand, CreateBranchStoreResult>
    {
        private readonly IBranchStoreRepository _branchStoreRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public CreateBranchStoreHandler(IBranchStoreRepository branchStoreRepository, IStoreRepository storeRepository, IMapper mapper)
        {
            _branchStoreRepository = branchStoreRepository;
            _storeRepository = storeRepository;
            _mapper = mapper;
        }
        public async Task<CreateBranchStoreResult> Handle(CreateBranchStoreCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateBranchStoreCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingBranchStore = _branchStoreRepository.GetBranchStoreByName(command.NameBranch);

            if (existingBranchStore != null)
                throw new InvalidOperationException($"BranchStore with Name {existingBranchStore.NameBranch} already exists");

            var existingStore = _storeRepository.GetStoreById(command.IdStore);
            if (existingStore == null)
                throw new InvalidOperationException($"Store with Id {command.IdStore} not exists");
            var branchStore = _mapper.Map<BranchStore>(command);
            var createdBranchStore = _branchStoreRepository.Insert(branchStore);
            _branchStoreRepository.SaveChanges();
            var result = _mapper.Map<CreateBranchStoreResult>(createdBranchStore);
            return result;
        }
    }
}
