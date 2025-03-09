using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IStoreRepository:IBaseRepository<Store>
    {
        Store GetStoreByName(string Name);

        Store? GetStoreById(Guid Id);
    }
}
