using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Services
{
    public static class ItemService
    {
        public static decimal ResolveDiscountItem(decimal oldQuant, decimal newQuant, decimal price)
        {
            decimal totalQuant = oldQuant + newQuant;

            if (totalQuant > 10 && totalQuant < 20)
            {
                return 20;
            }

            if (totalQuant >= 4)
            {
                return 10;
            }

            return 0M;
        }

        public static bool ValidateQuantItem(decimal oldQuant, decimal newQuant)
        {
            return (oldQuant + newQuant) <= 20;
        }

        public static decimal VerifyItens(List<SaleItem> itens) 
        {
            var joinedByProduct = itens
           .GroupBy(p => p.IdProdct)
            .ToDictionary(g => g.Key,                     
                          g => g.Sum(a=> a.Quantity));

            var itemEqual10orMore = joinedByProduct.Where(a => a.Value > 10);

            if (itemEqual10orMore.Any()) 
            {
                return 20;
            }

            var itemsMore4 = joinedByProduct.Where(a => a.Value > 4);
            if (itemsMore4.Any()) 
            {
                return 10;
            }
            return 0;
        }
    }
}
