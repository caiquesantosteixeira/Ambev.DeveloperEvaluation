using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    public class DeleteSaleResult
    {
        public DeleteSaleResult(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
