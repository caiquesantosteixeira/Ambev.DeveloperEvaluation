using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Customers.DeleteCustomer
{
    public class DeleteCustomerResult
    {
        public DeleteCustomerResult(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }

    }
}
