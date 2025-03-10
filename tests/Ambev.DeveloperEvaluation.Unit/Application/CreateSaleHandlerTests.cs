using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    using Moq;
    using Xunit;
    using FluentAssertions;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
    using Ambev.DeveloperEvaluation.Domain.Entities;
    using Ambev.DeveloperEvaluation.Domain.Repositories;
    using System.ComponentModel.DataAnnotations;

    public class CreateSaleHandlerTests
    {
        private readonly Mock<ISalesRepository> _mockSalesRepository;
        private readonly Mock<IBranchStoreRepository> _mockBranchStoreRepository;
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CreateSaleHandler _handler;

        public CreateSaleHandlerTests()
        {
            _mockSalesRepository = new Mock<ISalesRepository>();
            _mockBranchStoreRepository = new Mock<IBranchStoreRepository>();
            _mockCustomerRepository = new Mock<ICustomerRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new CreateSaleHandler(_mockSalesRepository.Object, _mockBranchStoreRepository.Object, _mockCustomerRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Handle_ShouldThrowValidationException_WhenValidationFails()
        {
            // Arrange
            var command = new CreateSaleCommand { IdBranchStore = Guid.NewGuid(), IdCustomer = Guid.NewGuid() };
            var validatorMock = new Mock<CreateSaleCommandValidator>();
            var validationResult = new FluentValidation.Results.ValidationResult();
            validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure("BranchStore", "Invalid branch store"));
            validatorMock.Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>())).ReturnsAsync(validationResult);

            // Act & Assert
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            await act.Should().ThrowAsync<ValidationException>()
                .WithMessage("BranchStore: Invalid branch store");
        }

        [Fact]
        public async Task Handle_ShouldThrowInvalidOperationException_WhenBranchStoreNotFound()
        {
            // Arrange
            var command = new CreateSaleCommand { IdBranchStore = Guid.NewGuid(), IdCustomer = Guid.NewGuid() };
            _mockBranchStoreRepository.Setup(r => r.GetById(command.IdBranchStore)).Returns((BranchStore)null);

            // Act & Assert
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage($"BranchStore with Id {command.IdBranchStore} not exists");
        }

        [Fact]
        public async Task Handle_ShouldThrowInvalidOperationException_WhenCustomerNotFound()
        {
            // Arrange
            var command = new CreateSaleCommand { IdBranchStore = Guid.NewGuid(), IdCustomer = Guid.NewGuid() };
            var existingBranchStore = new BranchStore { Id = command.IdBranchStore, NameBranch = "Store1" };
            _mockBranchStoreRepository.Setup(r => r.GetById(command.IdBranchStore)).Returns(existingBranchStore);
            _mockCustomerRepository.Setup(r => r.GetById(command.IdCustomer)).Returns((Customer)null);

            // Act & Assert
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage($"Customer with Id {command.IdBranchStore} not exists");
        }

        [Fact]
        public async Task Handle_ShouldCreateSale_WhenCommandIsValid()
        {
            // Arrange
            var command = new CreateSaleCommand { IdBranchStore = Guid.NewGuid(), IdCustomer = Guid.NewGuid() };
            var existingBranchStore = new BranchStore { Id = command.IdBranchStore, NameBranch = "Store1" };
            var existingCustomer = new Customer { Id = command.IdCustomer, Name = "Customer1" };
            var sale = new Sale { IdBranchStore = command.IdBranchStore, IdCustomer = command.IdCustomer };
            var createdSale = new Sale { Id = Guid.NewGuid(), BrancheStoreName = "Store1", CustomerName = "Customer1" };
            var result = new CreateSaleResult {  BrancheStoreName = createdSale.BrancheStoreName, CustomerName = createdSale.CustomerName };

            _mockBranchStoreRepository.Setup(r => r.GetById(command.IdBranchStore)).Returns(existingBranchStore);
            _mockCustomerRepository.Setup(r => r.GetById(command.IdCustomer)).Returns(existingCustomer);
            _mockMapper.Setup(m => m.Map<Sale>(command)).Returns(sale);
            _mockSalesRepository.Setup(r => r.Insert(sale)).Returns(createdSale);
            _mockMapper.Setup(m => m.Map<CreateSaleResult>(createdSale)).Returns(result);

            // Act
            var response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            response.Should().BeEquivalentTo(result);
            _mockSalesRepository.Verify(r => r.Insert(sale), Times.Once);
            _mockSalesRepository.Verify(r => r.SaveChanges(), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenSalesRepositoryFails()
        {
            // Arrange
            var command = new CreateSaleCommand { IdBranchStore = Guid.NewGuid(), IdCustomer = Guid.NewGuid() };
            var existingBranchStore = new BranchStore { Id = command.IdBranchStore, NameBranch = "Store1" };
            var existingCustomer = new Customer { Id = command.IdCustomer, Name = "Customer1" };
            var sale = new Sale { IdBranchStore = command.IdBranchStore, IdCustomer = command.IdCustomer };
            _mockBranchStoreRepository.Setup(r => r.GetById(command.IdBranchStore)).Returns(existingBranchStore);
            _mockCustomerRepository.Setup(r => r.GetById(command.IdCustomer)).Returns(existingCustomer);
            _mockMapper.Setup(m => m.Map<Sale>(command)).Returns(sale);
            _mockSalesRepository.Setup(r => r.Insert(sale)).Throws(new Exception("Database Error"));

            // Act & Assert
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            await act.Should().ThrowAsync<Exception>().WithMessage("Database Error");
        }
    }

}
