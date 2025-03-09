using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Stores.CreateStore
{
    public class CreateStoretHandler : IRequestHandler<CreateStoreCommand, CreateStoreResult>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public CreateStoretHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }
        public async Task<CreateStoreResult> Handle(CreateStoreCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateStoreCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingStore = _storeRepository.GetStoreByName(command.NameStore);

            if (existingStore != null)
                throw new InvalidOperationException($"Store with Name {existingStore.NameStore} already exists");

            var store = _mapper.Map<Store>(command);
            var createdStore = _storeRepository.Insert(store);
            _storeRepository.SaveChanges();
            var result = _mapper.Map<CreateStoreResult>(createdStore);
            return result;
        }
    }
}
