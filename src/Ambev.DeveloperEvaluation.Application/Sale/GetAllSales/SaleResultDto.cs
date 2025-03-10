using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    public class SaleResultDto
    {
        public Guid Id { get; set; }
        public DateTime DateVenda { get; set; }
        public decimal Total { get; set; }
        public bool Canceled { get; set; }
        public Guid IdBranchStore { get; set; }
        public Guid IdCustomer { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string BrancheStoreName { get; set; } = string.Empty;
    }
}
