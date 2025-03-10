using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SalesItemsRepository : BaseRepository<SaleItem>, ISalesItemsRepository
    {
        private readonly DefaultContext _context;
        public SalesItemsRepository(DefaultContext context) : base(context)
        {
            _context = context;
        }

        public decimal GetQuantItensByProduct(Guid idProduct) 
        {
            var ret = _context.SaleItem.Where(a => a.IdProdct == idProduct).Sum(a => a.Quantity);
            return ret;
        }
    }
}
