using Ambev.DeveloperEvaluation.Application.SalesItens.CreateSalesItens;
using Ambev.DeveloperEvaluation.Application.Services;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSalesItens
{
    public class CreateSaleItenHandler : IRequestHandler<CreateSaleItensCommand, CreateSaleItenResult>
    {
        private readonly ISalesItemsRepository _salesItemsRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;

        public CreateSaleItenHandler(ISalesItemsRepository salesItemsRepository, IProductRepository productRepository, ISalesRepository salesRepository, IMapper mapper)
        {
            _salesItemsRepository = salesItemsRepository;
            _productRepository = productRepository;
            _salesRepository = salesRepository;
            _mapper = mapper;
        }
        public async Task<CreateSaleItenResult> Handle(CreateSaleItensCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleItenCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingProduct = _productRepository.GetById(command.IdProdct);
            if(existingProduct == null)
                throw new InvalidOperationException($"Product with Id {command.IdProdct} not exists");

            var existingSale = _salesRepository.GetById(command.IdSale);
            if (existingSale == null)
                throw new InvalidOperationException($"Sale with Id {command.IdSale} not exists");

            var oldQuant = _salesItemsRepository.GetQuantItensByProduct(command.IdProdct);
            var isValidItem = ItemService.ValidateQuantItem(oldQuant, command.Quantity);
            if (!isValidItem) 
            {
                throw new InvalidOperationException($"This Product item Have more than 20 itens");
            }

            var saleIten = _mapper.Map<SaleItem>(command);
            saleIten.ProductName = existingProduct.Name;

            var createdProduct = _salesItemsRepository.Insert(saleIten);
            _salesItemsRepository.SaveChanges();
            var result = _mapper.Map<CreateSaleItenResult>(createdProduct);
            return result;
        }
    }
}
