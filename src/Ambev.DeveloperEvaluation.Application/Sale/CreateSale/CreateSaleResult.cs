using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleResult
    {
        public DateTime DateVenda { get; set; }
        public decimal Total { get; set; }
        public bool Canceled { get; set; }
        public int IdBranchStore { get; set; }
        public int IdCustomer { get; set; }
    }
}
