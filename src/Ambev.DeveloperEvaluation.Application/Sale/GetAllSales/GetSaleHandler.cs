using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

/// <summary>
/// Handler for processing GetUserCommand requests
/// </summary>
public class GetSaleHandler : IRequestHandler<GetAllSalesCommand, List<SaleResultDto>>
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

    public async Task<List<SaleResultDto>> Handle(GetAllSalesCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetAllSalesValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = _saleRepository.GetAll().ToList();

        return _mapper.Map<List<SaleResultDto>>(user);
    }
}
