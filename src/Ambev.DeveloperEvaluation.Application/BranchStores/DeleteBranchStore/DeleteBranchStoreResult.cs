using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.BranchStores.DeleteBranchStore
{
    public class DeleteBranchStoreResult
    {
        public DeleteBranchStoreResult(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
