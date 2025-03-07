using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product : BaseEntity
    {

        public DateTime DateInsert { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal PrecoUnitario { get; set; }

    }
}
