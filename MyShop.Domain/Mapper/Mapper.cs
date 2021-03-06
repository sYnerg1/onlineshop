﻿using AutoMapper;
using MyShop.Data.Models;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Domain.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AddProductDTO, Product>();
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();

            CreateMap<ShopCartItem, ShopCartItemDTO>()
                .ForMember(x => x.ProductName, x => x.MapFrom(y =>y.Product.Name))
                .ForMember(x => x.Price, x => x.MapFrom(y => y.Product.Price));

            CreateMap<ShopCartItemDTO, ShopCartItem>();

            CreateMap<OrderDetailDTO, OrderDetail>();
            CreateMap<OrderDetail, OrderDetailDTO>();

            CreateMap<OrderDTO, Order>();
            CreateMap<Order, OrderDTO>();

        }
    }
}
