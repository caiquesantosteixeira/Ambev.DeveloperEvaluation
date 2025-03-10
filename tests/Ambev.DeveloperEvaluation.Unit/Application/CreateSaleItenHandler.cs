using Moq;
using Xunit;
using FluentAssertions;
using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSalesItens;
using Ambev.DeveloperEvaluation.Application.SalesItens.CreateSalesItens;
using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Application.Tests.Sales
{
    public class CreateSaleItenHandlerTests
    {
        private readonly Mock<ISalesItemsRepository> _mockSalesItemsRepository;
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly Mock<ISalesRepository> _mockSalesRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CreateSaleItenHandler _handler;

        public CreateSaleItenHandlerTests()
        {
            _mockSalesItemsRepository = new Mock<ISalesItemsRepository>();
            _mockProductRepository = new Mock<IProductRepository>();
            _mockSalesRepository = new Mock<ISalesRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new CreateSaleItenHandler(_mockSalesItemsRepository.Object, _mockProductRepository.Object, _mockSalesRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Handle_ShouldThrowValidationException_WhenValidationFails()
        {
            // Arrange
            var command = new CreateSaleItensCommand { IdProdct = Guid.NewGuid(), IdSale = Guid.NewGuid(), Quantity = 5 };
            var validatorMock = new Mock<CreateSaleItenCommandValidator>();
            var validationResult = new FluentValidation.Results.ValidationResult();
            validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure("Quantity", "Quantity is invalid"));
            validatorMock.Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>())).ReturnsAsync(validationResult);

            // Act & Assert
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            await act.Should().ThrowAsync<ValidationException>()
                .WithMessage("Quantity: Quantity is invalid");
        }

        [Fact]
        public async Task Handle_ShouldThrowInvalidOperationException_WhenProductNotFound()
        {
            // Arrange
            var command = new CreateSaleItensCommand { IdProdct = Guid.NewGuid(), IdSale = Guid.NewGuid(), Quantity = 5 };
            _mockProductRepository.Setup(r => r.GetById(command.IdProdct)).Returns((Product)null);

            // Act & Assert
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage($"Product with Id {command.IdProdct} not exists");
        }

        [Fact]
        public async Task Handle_ShouldThrowInvalidOperationException_WhenSaleNotFound()
        {
            // Arrange
            var command = new CreateSaleItensCommand { IdProdct = Guid.NewGuid(), IdSale = Guid.NewGuid(), Quantity = 5 };
            var existingProduct = new Product { Id = command.IdProdct, Name = "Product1" };
            _mockProductRepository.Setup(r => r.GetById(command.IdProdct)).Returns(existingProduct);
            _mockSalesRepository.Setup(r => r.GetById(command.IdSale)).Returns((Sale)null);

            // Act & Assert
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage($"Sale with Id {command.IdSale} not exists");
        }

        [Fact]
        public async Task Handle_ShouldThrowInvalidOperationException_WhenItemQuantityExceedsLimit()
        {
            // Arrange
            var command = new CreateSaleItensCommand { IdProdct = Guid.NewGuid(), IdSale = Guid.NewGuid(), Quantity = 25 };
            var existingProduct = new Product { Id = command.IdProdct, Name = "Product1" };
            var existingSale = new Sale { Id = command.IdSale, CustomerName = "Customer1" };

            _mockProductRepository.Setup(r => r.GetById(command.IdProdct)).Returns(existingProduct);
            _mockSalesRepository.Setup(r => r.GetById(command.IdSale)).Returns(existingSale);
            _mockSalesItemsRepository.Setup(r => r.GetQuantItensByProduct(command.IdProdct)).Returns(10); // Exceeds 20 items

            // Act & Assert
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("This Product item Have more than 20 itens");
        }

        [Fact]
        public async Task Handle_ShouldCreateSaleItem_WhenCommandIsValid()
        {
            // Arrange
            var command = new CreateSaleItensCommand { IdProdct = Guid.NewGuid(), IdSale = Guid.NewGuid(), Quantity = 5 };
            var existingProduct = new Product { Id = command.IdProdct, Name = "Product1", PrecoUnitario = 10 };
            var existingSale = new Sale { Id = command.IdSale, CustomerName = "Customer1" };
            var saleItem = new SaleItem { IdSale = command.IdSale, IdProdct = command.IdProdct, Quantity = command.Quantity };
            var createdSaleItem = new SaleItem { Id = Guid.NewGuid(), ProductName = "Product1", Quantity = 5 };
            var result = new CreateSaleItenResult { Id = createdSaleItem.Id, ProductName = createdSaleItem.ProductName, Quantity = createdSaleItem.Quantity };

            _mockProductRepository.Setup(r => r.GetById(command.IdProdct)).Returns(existingProduct);
            _mockSalesRepository.Setup(r => r.GetById(command.IdSale)).Returns(existingSale);
            _mockSalesItemsRepository.Setup(r => r.GetQuantItensByProduct(command.IdProdct)).Returns(10); // Valid quantity
            _mockMapper.Setup(m => m.Map<SaleItem>(command)).Returns(saleItem);
            _mockSalesItemsRepository.Setup(r => r.Insert(saleItem)).Returns(createdSaleItem);
            _mockMapper.Setup(m => m.Map<CreateSaleItenResult>(createdSaleItem)).Returns(result);

            // Act
            var response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            response.Should().BeEquivalentTo(result);
            _mockSalesItemsRepository.Verify(r => r.Insert(saleItem), Times.Once);
            _mockSalesItemsRepository.Verify(r => r.SaveChanges(), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenSalesItemsRepositoryFails()
        {
            // Arrange
            var command = new CreateSaleItensCommand { IdProdct = Guid.NewGuid(), IdSale = Guid.NewGuid(), Quantity = 5 };
            var existingProduct = new Product { Id = command.IdProdct, Name = "Product1" };
            var existingSale = new Sale { Id = command.IdSale, CustomerName = "Customer1" };
            var saleItem = new SaleItem { IdSale = command.IdSale, IdProdct = command.IdProdct, Quantity = command.Quantity };
            _mockProductRepository.Setup(r => r.GetById(command.IdProdct)).Returns(existingProduct);
            _mockSalesRepository.Setup(r => r.GetById(command.IdSale)).Returns(existingSale);
            _mockSalesItemsRepository.Setup(r => r.GetQuantItensByProduct(command.IdProdct)).Returns(10); // Valid quantity
            _mockSalesItemsRepository.Setup(r => r.Insert(saleItem)).Throws(new Exception("Database Error"));

            // Act & Assert
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            await act.Should().ThrowAsync<Exception>().WithMessage("Database Error");
        }
    }
}