using Ambev.DeveloperEvaluation.Application.Customers.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.DeleteCustomer
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerResult>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public DeleteCustomerHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<DeleteCustomerResult> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            var validator = new DeleteCustomerCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingCustomer = _customerRepository.GetCustomerByIdWithIncludes(command.Id);

            if (existingCustomer == null)
                throw new InvalidOperationException($"Customer with Id {command.Id} not exists");

            if (existingCustomer.Sales.Any())
                throw new InvalidOperationException($"Customer with Sales {existingCustomer.Email} cannot deleted");

            _customerRepository.Delete(existingCustomer);
            _customerRepository.SaveChanges();
            var result = _mapper.Map<DeleteCustomerResult>(new DeleteCustomerResult(existingCustomer.Id));
            return result;
        }
    }
}
