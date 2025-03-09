using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        public Guid IdSale { get; set; }
        public Guid IdProdct { get; set; }
        public int PercentualDescount { get; set; }
        public bool Canceled { get; set; }
        public decimal Quantity { get; set; }
        public Product Product { get; set; } = new Product();
        public Sale Sale { get; set; } = new Sale();
    }
}
