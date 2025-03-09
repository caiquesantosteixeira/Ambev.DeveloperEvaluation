using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    public class UpdateProductResult
    {
        public Guid Id { get; set; }
        public DateTime DateInsert { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string BarCode { get; set; } = string.Empty;
        public decimal PrecoUnitario { get; set; }
        public decimal Quantity { get; set; }
    }
}
