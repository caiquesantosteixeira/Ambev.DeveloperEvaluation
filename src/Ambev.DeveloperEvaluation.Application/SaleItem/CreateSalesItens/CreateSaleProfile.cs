using Ambev.DeveloperEvaluation.Application.Sales.CreateSalesItens;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.Application.SalesItens.CreateSalesItens
{
    public class CreateSaleItensProfile : Profile
    {
        public CreateSaleItensProfile()
        {
            CreateMap<CreateSaleItensCommand, SaleItem>();
            CreateMap<SaleItem, CreateSaleItenResult>();
        }
    }
}
