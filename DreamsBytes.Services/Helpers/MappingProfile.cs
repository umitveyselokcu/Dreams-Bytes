using AutoMapper;
using DreamsBytes.Core.Entites;
using DreamsBytes.Services.Models;

namespace DreamsBytes.Services.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<ShoppingCartItem, ShoppingCartItemViewModel>();
            CreateMap<User, UserViewModel>();
            CreateMap<ShoppingCartItem, OrderItem>();
            CreateMap<User, LoginViewModel>();
        }
    }
}
