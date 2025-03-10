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
        public static bool ValidateQuantItem(decimal oldQuant, decimal newQuant)
        {
            return (oldQuant + newQuant) <= 20;
        }

        public static decimal VerifyItens(List<SaleItem> itens) 
        {
            var joinedByProduct = itens.Where(a => !a.Canceled)
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

        public static decimal GetTotal(List<SaleItem> itens)
        {
            var joinedByProduct = itens.Where(a => !a.Canceled).ToList();
            var total = 0M;

            foreach (var item in joinedByProduct) 
            {
                var valor = item.Product.PrecoUnitario;
                var quantidade = item.Quantity;

                total += (valor * quantidade);
            }

            return total;
        }
    }
}
