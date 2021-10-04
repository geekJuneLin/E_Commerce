using AutoMapper;
using E_Commerce.Dtos;
using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Profiles
{
    public class ProductItemProfile : Profile
    {
        public ProductItemProfile()
        {
            CreateMap<ProductItem, ProductItemDto>();
            CreateMap<ProductItemCreateDto, ProductItem>();
            CreateMap<ProductItemUpdateDto, ProductItem>();
        }
    }
}
