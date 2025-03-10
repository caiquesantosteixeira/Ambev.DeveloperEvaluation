using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSalesItens
{
    public class CreateSaleItenResult
    {
        public Guid Id { get; set; }
        public Guid IdSale { get; set; }
        public Guid IdProdct { get; set; }
        public int PercentualDescount { get; set; }
        public bool Canceled { get; set; }
        public decimal Quantity { get; set; }
        public string ProductName { get; set; } = string.Empty;

    }
}
