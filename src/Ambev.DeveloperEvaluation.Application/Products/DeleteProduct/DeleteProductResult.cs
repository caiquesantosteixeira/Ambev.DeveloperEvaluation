using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct
{
    public class DeleteProductResult
    {
        public DeleteProductResult(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
