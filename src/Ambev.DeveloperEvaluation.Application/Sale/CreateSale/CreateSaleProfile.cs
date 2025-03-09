﻿using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleProfile : Profile
    {
        public CreateSaleProfile()
        {
            CreateMap<CreateSaleCommand, Sale>();
            CreateMap<Sale, CreateSaleResult>();
        }
    }
}
