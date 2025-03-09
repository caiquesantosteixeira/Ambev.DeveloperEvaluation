using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Application.SalesItens.DeleteSalesItens;
using Ambev.DeveloperEvaluation.Application.SalesItens.UpdateSalesItens;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSalesItens
{
    public class DeleteSaleItenHandler : IRequestHandler<DeleteSaleItensCommand, DeleteSaleItensResult>
    {
        private readonly ISalesItemsRepository _salesItemsRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;

        public DeleteSaleItenHandler(ISalesItemsRepository salesItemsRepository, IProductRepository productRepository, ISalesRepository salesRepository, IMapper mapper)
        {
            _salesItemsRepository = salesItemsRepository;
            _productRepository = productRepository;
            _salesRepository = salesRepository;
            _mapper = mapper;
        }
        public async Task<DeleteSaleItensResult> Handle(DeleteSaleItensCommand command, CancellationToken cancellationToken)
        {
            var validator = new DeleteSaleItenCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingItem = _salesItemsRepository.GetById(command.Id);
            if (existingItem == null)
                throw new InvalidOperationException($"Item with Id {command.Id} not exists");

            _salesItemsRepository.Delete(existingItem);
            _salesItemsRepository.SaveChanges();
            return new DeleteSaleItensResult(command.Id);
        }
    }
}
