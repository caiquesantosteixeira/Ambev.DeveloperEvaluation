using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class BranchStore : BaseEntity
    {
        public string NameBranch { get; set; } = string.Empty;
        public int IdStore { get; set;}
        public Store Store { get; set; } = new Store();
        public ICollection<Sale> Sales { get; set; } = [];
    }
}
