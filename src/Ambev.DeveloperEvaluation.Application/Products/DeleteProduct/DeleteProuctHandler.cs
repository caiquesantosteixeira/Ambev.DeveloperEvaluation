using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductResult>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var validator = new DeleteProductCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingProduct = _productRepository.GetByIdWithIncludes(command.Id);

            if (existingProduct == null)
                throw new InvalidOperationException($"Product with Id {command.Id} not exists");

            if(existingProduct.SalesItems.Any())
                throw new InvalidOperationException($"Product with Id {command.Id} cannot removed because have Sales Itens included");

            _productRepository.Delete(existingProduct);
            _productRepository.SaveChanges();
         
            return new DeleteProductResult(command.Id);
        }
    }
}
