using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResult>
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IBranchStoreRepository _branchStoreRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public DeleteSaleHandler(ISalesRepository salesRepository, IBranchStoreRepository branchStoreRepository, ICustomerRepository customerRepository, IMapper mapper)
        {
            _salesRepository = salesRepository;
            _branchStoreRepository = branchStoreRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<DeleteSaleResult> Handle(DeleteSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new DeleteSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingSale = _salesRepository.GetByIdWithIncludes(command.Id);     
            if (existingSale == null)
                throw new InvalidOperationException($"Sale with Id {command.Id} not exists");

            if(existingSale.SalesItems.Any())
                throw new InvalidOperationException($"Sale with Id {command.Id} cannot removed because have Itens included");


            var sale = _mapper.Map<Sale>(command);

            _salesRepository.Delete(sale);
            _salesRepository.SaveChanges();

            return new DeleteSaleResult(command.Id);
        }
    }
}
