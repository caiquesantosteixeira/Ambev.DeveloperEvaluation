using Ambev.DeveloperEvaluation.Domain.Entities;


namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISalesItemsRepository:IBaseRepository<SaleItem>
    {
        public decimal GetQuantItensByProduct(Guid idProduct);
    }
}
