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
    }
}
