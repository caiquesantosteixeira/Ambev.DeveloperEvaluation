
namespace Ambev.DeveloperEvaluation.WebApi.Features.Customer.UpdateCustomer;

/// <summary>
/// Represents a request to create a new Branchstore in the system.
/// </summary>
public class UpdateCustomerRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}