using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public Guid IdBranchStore { get; set; }
        public Guid IdCustomer { get; set; }
        [ForeignKey("IdBranchStore")]
        public BranchStore? BranchStore { get; set; }
        [ForeignKey("IdCustomer")]
        public Customer? Customer { get; set; }
        public ICollection<SaleItem> SalesItems { get; set; } = [];
    }
}
