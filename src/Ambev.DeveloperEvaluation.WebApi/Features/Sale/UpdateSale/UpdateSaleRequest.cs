﻿
namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

/// <summary>
/// Represents a request to create a new Branchstore in the system.
/// </summary>
public class UpdateSaleRequest
{
    public Guid Id { get; set; }
    public DateTime DateVenda { get; set; }
    public decimal Total { get; set; }
    public bool Canceled { get; set; }
    public bool Finalized { get; set; }
    public Guid IdBranchStore { get; set; }
    public Guid IdCustomer { get; set; }
}