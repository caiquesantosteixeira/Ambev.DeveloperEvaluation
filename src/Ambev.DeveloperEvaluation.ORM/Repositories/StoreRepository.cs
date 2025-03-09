using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
        private readonly DefaultContext _context;
        public StoreRepository(DefaultContext context) : base(context)
        {
            _context = context;
        }

        public Store? GetStoreByName(string Name) 
        {
            return _context.Store.FirstOrDefault(a => a.NameStore == Name);
        }

        public Store? GetStoreById(Guid Id)
        {
            return _context.Store.FirstOrDefault(a => a.Id == Id);
        }

    }
}
