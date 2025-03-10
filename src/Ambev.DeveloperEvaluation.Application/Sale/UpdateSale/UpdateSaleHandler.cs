using Ambev.DeveloperEvaluation.Application.Services;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IBranchStoreRepository _branchStoreRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public UpdateSaleHandler(ISalesRepository salesRepository, IBranchStoreRepository branchStoreRepository, ICustomerRepository customerRepository, IMapper mapper)
        {
            _salesRepository = salesRepository;
            _branchStoreRepository = branchStoreRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingSale = _salesRepository.GetById(command.Id);     
            if (existingSale == null)
                throw new InvalidOperationException($"Sale with Id {command.Id} not exists");

            var existingBranchStore = _branchStoreRepository.GetById(command.IdBranchStore);
            if (existingBranchStore == null)
                throw new InvalidOperationException($"BranchStore with Id {command.IdBranchStore} not exists");

            var existingCustomer = _customerRepository.GetById(command.IdCustomer);
            if (existingCustomer == null)
                throw new InvalidOperationException($"Customer with Id {command.IdCustomer} not exists");

            var sale = _mapper.Map<Sale>(command);
            sale.BrancheStoreName = existingBranchStore.NameBranch;
            sale.CustomerName = existingCustomer.Name;

            if (command.Finalized)
            {
                var saleWithIncludes = _salesRepository.GetByIdWithIncludes(command.Id);
                var descount = ItemService.VerifyItens(saleWithIncludes.SalesItems.ToList());
                sale.Descount = descount;
                var total = ItemService.GetTotal(saleWithIncludes.SalesItems.ToList());
                sale.Total = total;
            }

            var createdProduct = _salesRepository.Update(sale);
            _salesRepository.SaveChanges();
            var result = _mapper.Map<UpdateSaleResult>(createdProduct);
            return result;
        }
    }
}
