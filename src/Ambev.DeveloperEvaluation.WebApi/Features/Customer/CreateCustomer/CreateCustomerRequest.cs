
namespace Ambev.DeveloperEvaluation.WebApi.Features.Customer.CreateCustomer;

/// <summary>
/// Represents a request to create a new Branchstore in the system.
/// </summary>
public class CreateCustomerRequest
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}