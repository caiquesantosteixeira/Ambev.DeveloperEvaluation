using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public DateTime DateVenda { get; set; }
        public decimal Total { get; set; }
        public bool Canceled { get; set; }
        public int IdBranchStore { get; set; }
        public int IdCustomer { get; set; }
        public BranchStore BranchStore { get; set; } = new BranchStore();
        public Customer Customer { get; set; } = new Customer();
        public ICollection<SaleItem> SalesItems { get; set; } = [];
    }
}
