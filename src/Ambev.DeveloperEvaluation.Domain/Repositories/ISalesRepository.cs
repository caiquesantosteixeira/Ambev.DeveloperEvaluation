using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISalesRepository:IBaseRepository<Sale>
    {
        List<Sale> GetSalesByIdCustomer(Guid id);

        Sale GetByIdWithIncludes(Guid id);
    }
}
