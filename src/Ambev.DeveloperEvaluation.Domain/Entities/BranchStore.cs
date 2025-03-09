using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class BranchStore : BaseEntity
    {
        public string NameBranch { get; set; } = string.Empty;
        
        public Guid IdStore { get; set;}
        [ForeignKey("IdStore")]
        public Store? Store { get; set; }
        public ICollection<Sale> Sales { get; set; } = [];
    }
}
