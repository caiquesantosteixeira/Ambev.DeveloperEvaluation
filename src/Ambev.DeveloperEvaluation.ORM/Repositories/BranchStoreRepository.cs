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
    public class BranchStoreRepository:BaseRepository<BranchStore>,IBranchStoreRepository
    {
        private readonly DefaultContext _context;

        public BranchStoreRepository(DefaultContext context) : base(context)
        {
            _context = context;
        }

        public BranchStore? GetBranchStoreByName(string name) 
        {
            return _context.BranchStore.FirstOrDefault(a => a.NameBranch == name);
        }

        public BranchStore GetBranchStoreByIdWithIncludes(Guid id)
        {
            return _context.BranchStore.Include(a => a.Store).Include(a => a.Sales).First(a => a.Id == id);
        }
    }
}
