using Ambev.DeveloperEvaluation.Application.Customers.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.UpdateCustomer
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerResult>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<UpdateCustomerResult> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateCustomerCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingCustomer = _customerRepository.GetCustomerByEmail(command.Email);

            if (existingCustomer == null)
                throw new InvalidOperationException($"Customer with email {command.Email} not exists");

            var customer = _mapper.Map<Customer>(command);
            var createdProduct = _customerRepository.Update(customer);
            _customerRepository.SaveChanges();
            var result = _mapper.Map<UpdateCustomerResult>(createdProduct);
            return result;
        }
    }
}
