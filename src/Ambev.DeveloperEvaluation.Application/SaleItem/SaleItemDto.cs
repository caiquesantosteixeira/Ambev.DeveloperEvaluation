using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.SalesItem
{
    public class SaleItemDto
    {
        public Guid IdSale { get; set; }
        public Guid IdProdct { get; set; }
        public bool Canceled { get; set; }
        public decimal Quantity { get; set; }
        public string ProductName { get; set; } = string.Empty;
    }
}
