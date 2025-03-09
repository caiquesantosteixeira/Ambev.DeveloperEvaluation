using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IBranchStoreRepository _branchStoreRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CreateSaleHandler(ISalesRepository salesRepository, IBranchStoreRepository branchStoreRepository,ICustomerRepository customerRepository, IMapper mapper)
        {
            _salesRepository = salesRepository;
            _branchStoreRepository = branchStoreRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);


            var existingBranchStore = _branchStoreRepository.GetById(command.IdBranchStore);
            if (existingBranchStore == null)
                throw new InvalidOperationException($"BranchStore with Id {command.IdBranchStore} not exists");

            var existingCustomer = _customerRepository.GetById(command.IdCustomer);
            if (existingCustomer == null)
                throw new InvalidOperationException($"Customer with Id {command.IdBranchStore} not exists");

            var sale = _mapper.Map<Sale>(command);

            var createdProduct = _salesRepository.Insert(sale);
            _salesRepository.SaveChanges();
            var result = _mapper.Map<CreateSaleResult>(createdProduct);
            return result;
        }
    }
}
