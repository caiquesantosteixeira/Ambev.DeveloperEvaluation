using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.Application.Customers.CreateProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentAssertions;
using Moq;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class CreateCustomerHandlerTests
    {
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CreateCustomerHandler _handler;

        public CreateCustomerHandlerTests()
        {
            _mockCustomerRepository = new Mock<ICustomerRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new CreateCustomerHandler(_mockCustomerRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Handle_ShouldThrowValidationException_WhenValidationFails()
        {
            // Arrange
            var command = new CreateCustomerCommand { Email = "invalidemail" }; // Exemplo de dados inválidos para o comando
            var validatorMock = new Mock<CreateCustomerCommandValidator>();
            var validationResult = new FluentValidation.Results.ValidationResult();
            validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure("Email", "Invalid email"));
            validatorMock.Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>())).ReturnsAsync(validationResult);

            // Act & Assert
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            await act.Should().ThrowAsync<ValidationException>()
                .WithMessage("Email: Invalid email");
        }

        [Fact]
        public async Task Handle_ShouldThrowInvalidOperationException_WhenEmailAlreadyExists()
        {
            // Arrange
            var command = new CreateCustomerCommand { Email = "test@example.com" };
            var existingCustomer = new Customer { Email = "test@example.com" };
            _mockCustomerRepository.Setup(r => r.GetCustomerByEmail(command.Email)).Returns(existingCustomer);

            // Act & Assert
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("Customer with email test@example.com already exists");
        }

        [Fact]
        public async Task Handle_ShouldCreateCustomer_WhenCommandIsValid()
        {
            // Arrange
            var command = new CreateCustomerCommand { Email = "newcustomer@example.com" };
            var customer = new Customer { Email = command.Email };
            var createdProduct = new Customer { Email = "newcustomer@example.com" };
            var result = new CreateCustomerResult { Email = "newcustomer@example.com" };

            _mockCustomerRepository.Setup(r => r.GetCustomerByEmail(command.Email)).Returns((Customer)null);
            _mockMapper.Setup(m => m.Map<Customer>(command)).Returns(customer);
            _mockCustomerRepository.Setup(r => r.Insert(customer)).Returns(createdProduct);
            _mockMapper.Setup(m => m.Map<CreateCustomerResult>(createdProduct)).Returns(result);

            // Act
            var response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            response.Should().BeEquivalentTo(result);
            _mockCustomerRepository.Verify(r => r.Insert(customer), Times.Once);
            _mockCustomerRepository.Verify(r => r.SaveChanges(), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenCustomerRepositoryFails()
        {
            // Arrange
            var command = new CreateCustomerCommand { Email = "newcustomer@example.com" };
            var customer = new Customer { Email = command.Email };
            _mockCustomerRepository.Setup(r => r.GetCustomerByEmail(command.Email)).Returns((Customer)null);
            _mockMapper.Setup(m => m.Map<Customer>(command)).Returns(customer);
            _mockCustomerRepository.Setup(r => r.Insert(customer)).Throws(new Exception("Database Error"));

            // Act & Assert
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            await act.Should().ThrowAsync<Exception>().WithMessage("Database Error");
        }
    }
}
