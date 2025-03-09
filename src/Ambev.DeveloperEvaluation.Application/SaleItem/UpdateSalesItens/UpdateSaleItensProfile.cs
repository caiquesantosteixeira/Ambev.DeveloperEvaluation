using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSalesItens;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.Application.SalesItens.UpdateSalesItens
{
    public class UpdateSaleItensProfile : Profile
    {
        public UpdateSaleItensProfile()
        {
            CreateMap<UpdateSaleItensCommand, SaleItem>();
            CreateMap<SaleItem, UpdateSaleItensResult>();
        }
    }
}
