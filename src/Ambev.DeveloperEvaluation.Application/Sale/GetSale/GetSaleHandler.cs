using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Handler for processing GetUserCommand requests
/// </summary>
public class GetSaleHandler : IRequestHandler<GetSaleCommand, GetSaleResult>
{
    private readonly ISalesRepository _saleRepository;
    private readonly IMapper _mapper;

    public GetSaleHandler(
        ISalesRepository saleRepository,
        IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<GetSaleResult> Handle(GetSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = _saleRepository.GetByIdWithIncludes(request.Id);
        if (user == null)
            throw new KeyNotFoundException($"Sale with ID {request.Id} not found");

        return _mapper.Map<GetSaleResult>(user);
    }
}
