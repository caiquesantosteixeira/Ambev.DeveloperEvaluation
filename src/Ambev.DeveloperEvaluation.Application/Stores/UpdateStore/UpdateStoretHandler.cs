using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Stores.UpdateStore
{
    public class UpdateStoretHandler : IRequestHandler<UpdateStoreCommand, UpdateStoreResult>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public UpdateStoretHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }
        public async Task<UpdateStoreResult> Handle(UpdateStoreCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateStoreCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingStore = _storeRepository.GetById(command.Id);

            if (existingStore == null)
                throw new InvalidOperationException($"Store with Id {command.Id} not exists");

            var store = _mapper.Map<Store>(command);
            var createdStore = _storeRepository.Update(store);
            _storeRepository.SaveChanges();
            var result = _mapper.Map<UpdateStoreResult>(createdStore);
            return result;
        }
    }
}
