using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Store.UpdateStore;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.DeleteUser;
using Ambev.DeveloperEvaluation.Application.BranchStores.DeleteBranchStore;
using Ambev.DeveloperEvaluation.WebApi.Features.BranchStore.CreateBranchStore;
using Ambev.DeveloperEvaluation.Application.BranchStores.CreateBranchStore;
using Ambev.DeveloperEvaluation.WebApi.Features.BranchStore.UpdateBranchStore;
using Ambev.DeveloperEvaluation.Application.BranchStores.UpdateBranchStore;
using Microsoft.AspNetCore.Authorization;

namespace Ambev.DeveloperEvaluation.WebApi.Features.BranchStore;

/// <summary>
/// Controller for Store Crud
/// </summary>
[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class BranchStoreController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    /// <summary>
    /// Initializes a new instance of AuthController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public BranchStoreController(IMediator mediator, IMapper mapper)
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
    [ProducesResponseType(typeof(ApiResponseWithData<CreateBranchStoreResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateBranchStore([FromBody] CreateBranchStoreRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateBranchStoreRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateBranchStoreCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateBranchStoreResponse>
        {
            Success = true,
            Message = "BranchStore created successfully",
            Data = _mapper.Map<CreateBranchStoreResponse>(response)
        });
    }

    /// <summary>
    /// Update a Branch
    /// </summary>
    /// <param name="request">The authentication request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Authentication token if successful</returns>
    [HttpPut]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateBranchStoreResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateBranchStore([FromBody] UpdateBranchStoreRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateBranchStoreRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<UpdateBranchStoreCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<UpdateBranchStoreResponse>
        {
            Success = true,
            Message = "Branch Store updated successfully",
            Data = _mapper.Map<UpdateBranchStoreResponse>(response)
        });
    }

    /// <summary>
    /// Deletes a Branch by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the user to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the user was deleted</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBranchStore([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteUserRequest { Id = id };
        var validator = new DeleteUserRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteBranchStoreCommand>(request.Id);
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "BranchStore deleted successfully"
        });
    }
}
