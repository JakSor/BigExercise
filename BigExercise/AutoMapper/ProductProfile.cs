using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using DTO;

namespace BigExercise.AutoMapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Food, ProductDTO>().ReverseMap();
            CreateMap<NonFood, ProductDTO>().ReverseMap();
            CreateMap<ShoppingBasket, ShoppingBasketDTO>().ReverseMap();
            CreateMap<ShoppingBasketItem, ShoppingBasketDTO>().ReverseMap();

        }
    }
}
