using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SalesRepository : BaseRepository<Sale>, ISalesRepository
    {
        private readonly DefaultContext _context;
        public SalesRepository(DefaultContext context) : base(context)
        {
            _context = context;
        }

        public List<Sale> GetSalesByIdCustomer(Guid id) 
        {
            return _context.Sale.Where(a => a.IdCustomer == id).ToList();
        }

        public Sale GetByIdWithIncludes(Guid id) 
        {
            return _context.Sale.Include(a => a.SalesItems).AsNoTracking().First(a => a.Id == id);
        }
    }
}
