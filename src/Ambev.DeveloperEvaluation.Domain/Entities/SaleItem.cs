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
        public int IdSale { get; set; }
        public int IdProdct { get; set; }
        public int PercentualDescount { get; set; }
        public bool Canceled { get; set; }
        public Product Product { get; set; } = new Product();
        public Sale Sale { get; set; } = new Sale();
    }
}
