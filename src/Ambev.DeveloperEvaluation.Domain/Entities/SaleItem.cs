using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        public Guid IdSale { get; set; }
        public Guid IdProdct { get; set; }
        public bool Canceled { get; set; }
        public decimal Quantity { get; set; }
        public string ProductName { get; set; } = string.Empty;

        [ForeignKey("IdProdct")]
        public Product? Product { get; set; }
        [ForeignKey("IdSale")]
        public Sale? Sale { get; set; }
    }
}
