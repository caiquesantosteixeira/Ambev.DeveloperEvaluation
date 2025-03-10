using Ambev.DeveloperEvaluation.Application.Services;
using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class ItemServiceTests
    {
        [Fact]
        public void VerifyItens_ShouldReturn20_WhenItemQuantityIsGreaterThan10()
        {
            // Arrange
            var itens = new List<SaleItem>
        {
            new SaleItem { IdProdct = Guid.NewGuid(), Quantity = 12, Canceled = false, ProductName = "Product A" },
            new SaleItem { IdProdct = Guid.NewGuid(), Quantity = 5, Canceled = false, ProductName = "Product B" },
        };

            // Act
            var result = ItemService.VerifyItens(itens);

            // Assert
            Assert.Equal(20, result);
        }

        [Fact]
        public void VerifyItens_ShouldReturn10_WhenItemQuantityIsGreaterThan4AndLessThanOrEqualTo10()
        {
            // Arrange
            var itens = new List<SaleItem>
        {
            new SaleItem { IdProdct = Guid.NewGuid(), Quantity = 8, Canceled = false, ProductName = "Product A" },
            new SaleItem { IdProdct = Guid.NewGuid(), Quantity = 5, Canceled = false, ProductName = "Product B" },
        };

            // Act
            var result = ItemService.VerifyItens(itens);

            // Assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void VerifyItens_ShouldReturn0_WhenNoItemQuantityIsGreaterThan4()
        {
            // Arrange
            var itens = new List<SaleItem>
        {
            new SaleItem { IdProdct = Guid.NewGuid(), Quantity = 2, Canceled = false, ProductName = "Product A" },
            new SaleItem { IdProdct = Guid.NewGuid(), Quantity = 3, Canceled = false, ProductName = "Product B" },
        };

            // Act
            var result = ItemService.VerifyItens(itens);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void VerifyItens_ShouldIgnoreCanceledItems()
        {
            // Arrange
            var itens = new List<SaleItem>
        {
            new SaleItem { IdProdct = Guid.NewGuid(), Quantity = 12, Canceled = true, ProductName = "Product A" },
            new SaleItem { IdProdct = Guid.NewGuid(), Quantity = 6, Canceled = false, ProductName = "Product B" },
        };

            // Act
            var result = ItemService.VerifyItens(itens);

            // Assert
            Assert.Equal(10, result); // O item cancelado é ignorado, e o restante é avaliado.
        }

        [Fact]
        public void VerifyItens_ShouldReturn0_WhenAllItemsAreCanceled()
        {
            // Arrange
            var itens = new List<SaleItem>
        {
            new SaleItem { IdProdct = Guid.NewGuid(), Quantity = 12, Canceled = true, ProductName = "Product A" },
            new SaleItem { IdProdct = Guid.NewGuid(), Quantity = 5, Canceled = true, ProductName = "Product B" },
        };

            // Act
            var result = ItemService.VerifyItens(itens);

            // Assert
            Assert.Equal(0, result); // Nenhum item válido, portanto retorna 0.
        }

        // O método VerifyItens

        [Fact]
        public void GetTotal_ShouldReturnCorrectTotal_WhenMultipleItems()
        {
            // Arrange
            var produto1 = new Product { PrecoUnitario = 10 };
            var produto2 = new Product { PrecoUnitario = 20 };

            var itens = new List<SaleItem>
        {
            new SaleItem { IdProdct = Guid.NewGuid(), Quantity = 2, Canceled = false, Product = produto1 },
            new SaleItem { IdProdct = Guid.NewGuid(), Quantity = 3, Canceled = false, Product = produto2 }
        };

            // Act
            var result = ItemService.GetTotal(itens);

            // Assert
            // (10 * 2) + (20 * 3) = 20 + 60 = 80
            Assert.Equal(80, result);
        }

        [Fact]
        public void GetTotal_ShouldIgnoreCanceledItems()
        {
            // Arrange
            var produto1 = new Product { PrecoUnitario = 10 };
            var produto2 = new Product { PrecoUnitario = 20 };

            var itens = new List<SaleItem>
        {
            new SaleItem { IdProdct = Guid.NewGuid(), Quantity = 2, Canceled = true, Product = produto1 },
            new SaleItem { IdProdct = Guid.NewGuid(), Quantity = 3, Canceled = false, Product = produto2 }
        };

            // Act
            var result = ItemService.GetTotal(itens);

            // Assert
            // (item cancelado não conta), então o total é (20 * 3) = 60
            Assert.Equal(60, result);
        }

        [Fact]
        public void GetTotal_ShouldReturnCorrectTotal_WhenSingleItem()
        {
            // Arrange
            var produto1 = new Product { PrecoUnitario = 15 };

            var itens = new List<SaleItem>
        {
            new SaleItem { IdProdct = Guid.NewGuid(), Quantity = 4, Canceled = false, Product = produto1 }
        };

            // Act
            var result = ItemService.GetTotal(itens);

            // Assert
            // (15 * 4) = 60
            Assert.Equal(60, result);
        }

        [Fact]
        public void GetTotal_ShouldReturnZero_WhenNoItems()
        {
            // Arrange
            var itens = new List<SaleItem>(); // Lista vazia

            // Act
            var result = ItemService.GetTotal(itens);

            // Assert
            Assert.Equal(0, result);
        }

    }
}
