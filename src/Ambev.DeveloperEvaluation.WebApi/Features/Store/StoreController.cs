using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Store.UpdateStore;
using Ambev.DeveloperEvaluation.WebApi.Features.BranchStore.CreateBranchStore;
using Ambev.DeveloperEvaluation.Application.BranchStores.CreateBranchStore;
using Ambev.DeveloperEvaluation.WebApi.Features.BranchStore.UpdateBranchStore;
using Ambev.DeveloperEvaluation.Application.BranchStores.UpdateBranchStore;
using Ambev.DeveloperEvaluation.Application.Stores.UpdateStore;
using Ambev.DeveloperEvaluation.WebApi.Features.Store.CreateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Store.CreateStore;
using Ambev.DeveloperEvaluation.Application.Stores.CreateStore;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Store;

/// <summary>
/// Controller for Store Crud
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class StoreController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of AuthController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public StoreController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Insert A new BranchStore
    /// </summary>
    /// <param name="request">The authentication request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Authentication token if successful</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateStoreResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateStore([FromBody] CreateStoreRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateStoreRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateStoreCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateStoreResponse>
        {
            Success = true,
            Message = "Store created successfully",
            Data = _mapper.Map<CreateStoreResponse>(response)
        });
    }

    /// <summary>
    /// Update a BranchStore
    /// </summary>
    /// <param name="request">The authentication request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Authentication token if successful</returns>
    [HttpPut]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateStoreResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateStore([FromBody] UpdateBranchStoreRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateBranchStoreRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<UpdateStoreCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<UpdateStoreResponse>
        {
            Success = true,
            Message = "Store updated successfully",
            Data = _mapper.Map<UpdateStoreResponse>(response)
        });
    }
}
