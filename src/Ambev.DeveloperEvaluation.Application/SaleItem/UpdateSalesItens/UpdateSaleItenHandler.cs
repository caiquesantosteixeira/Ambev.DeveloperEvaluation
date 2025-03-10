using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Application.SalesItens.UpdateSalesItens;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSalesItens
{
    public class UpdateSaleItenHandler : IRequestHandler<UpdateSaleItensCommand, UpdateSaleItensResult>
    {
        private readonly ISalesItemsRepository _salesItemsRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;

        public UpdateSaleItenHandler(ISalesItemsRepository salesItemsRepository, IProductRepository productRepository, ISalesRepository salesRepository, IMapper mapper)
        {
            _salesItemsRepository = salesItemsRepository;
            _productRepository = productRepository;
            _salesRepository = salesRepository;
            _mapper = mapper;
        }
        public async Task<UpdateSaleItensResult> Handle(UpdateSaleItensCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateSaleItenCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingItem = _salesItemsRepository.GetById(command.Id);
            if (existingItem == null)
                throw new InvalidOperationException($"Item with Id {command.Id} not exists");

            var existingProduct = _productRepository.GetById(command.IdProdct);
            if(existingProduct == null)
                throw new InvalidOperationException($"Product with Id {command.IdProdct} not exists");

            var existingSale = _salesRepository.GetById(command.IdSale);
            if (existingSale == null)
                throw new InvalidOperationException($"Sale with Id {command.IdSale} not exists");

            var saleIten = _mapper.Map<SaleItem>(command);
            saleIten.ProductName = existingProduct.Name;

            var createdProduct = _salesItemsRepository.Update(saleIten);
            _salesItemsRepository.SaveChanges();
            var result = _mapper.Map<UpdateSaleItensResult>(createdProduct);
            return result;
        }
    }
}
