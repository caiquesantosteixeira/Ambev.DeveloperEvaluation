using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IBranchStoreRepository:IBaseRepository<BranchStore>
    {
        BranchStore? GetBranchStoreByName(string name);
        BranchStore GetBranchStoreByIdWithIncludes(Guid id);
    }
}
