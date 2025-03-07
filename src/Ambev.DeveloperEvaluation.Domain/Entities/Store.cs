using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Store : BaseEntity
    {
        public string NameStore { get; set; } = string.Empty;
        public ICollection<BranchStore> BranchsStore { get; set; } = [];
    }
}
