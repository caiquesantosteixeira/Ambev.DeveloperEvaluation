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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly DefaultContext _context;
        public ProductRepository(DefaultContext context) : base(context)
        {
            _context = context;
        }

        public Product? GetProdutoByBarCode(string barCode)
        {
            return _context.Product.AsNoTracking().FirstOrDefault(a => a.BarCode == barCode);
        }

        public Product GetByIdWithIncludes(Guid id)
        {
            return _context.Product.Include(a => a.SalesItems).First(a => a.Id == id);
        }
    }
}
