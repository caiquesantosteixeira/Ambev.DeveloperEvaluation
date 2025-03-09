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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly DefaultContext _context;
        public CustomerRepository(DefaultContext context) : base(context)
        {
            _context = context;
        }

        public Customer? GetCustomerByEmail(string email) 
        {
            return _context.Customer.AsNoTracking().FirstOrDefault(a => a.Email == email);
        }

        public Customer GetCustomerByIdWithIncludes(Guid id)
        {
            return _context.Customer.Include(a=> a.Sales).First(a => a.Id == id);
        }
    }
}
