﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICustomerRepository:IBaseRepository<Customer>
    {
        Customer? GetCustomerByEmail(string email);
        Customer GetCustomerByIdWithIncludes(Guid id);
    }
}
