using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IProductRepository:IBaseRepository<Product>
    {
        Product? GetProdutoByBarCode(string barCode);
        Product GetByIdWithIncludes(Guid id);
    }
}
