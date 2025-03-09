using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.BranchStores.DeleteBranchStore
{
    public class DeleteBranchStoreHandler : IRequestHandler<DeleteBranchStoreCommand, DeleteBranchStoreResult>
    {
        private readonly IBranchStoreRepository _branchStoreRepository;


        public DeleteBranchStoreHandler(IBranchStoreRepository branchStoreRepository)
        {
            _branchStoreRepository = branchStoreRepository;
        }
        public async Task<DeleteBranchStoreResult> Handle(DeleteBranchStoreCommand command, CancellationToken cancellationToken)
        {
            var validator = new DeleteBranchStoreCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingBranchStore = _branchStoreRepository.GetBranchStoreByIdWithIncludes(command.Id);

            if (existingBranchStore == null)
                throw new InvalidOperationException($"BranchStore with Id {command.Id} not exists");

            if(existingBranchStore.Sales.Any())
                throw new InvalidOperationException($"BranchStore with Id {command.Id} cannot excluded because have sales itens.");


            _branchStoreRepository.Delete(existingBranchStore);
            _branchStoreRepository.SaveChanges();
            return new DeleteBranchStoreResult(existingBranchStore.Id);
        }
    }
}
