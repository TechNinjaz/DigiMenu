using AutoMapper;
using TechNinjaz.DigiMenu.Core.Entities;
using TechNinjaz.DigiMenu.Core.Entities.Identity;
using TechNinjaz.DigiMenu.Core.Entities.OrderEntities;
using TechNinjaz.DigiMenu.Presentation.ModelView;

namespace TechNinjaz.DigiMenu.Presentation.MapperFactory
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<MenuCategory, MenuCategoryModel>().ReverseMap();
            CreateMap<MenuItem, MenuItemModel>().ReverseMap();
            CreateMap<UserProfile, UserProfileModel>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailModel>().ReverseMap();
            CreateMap<SelectedMenuOption, SelectedOptionModel>().ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
            // .ForMember(dest => dest.CustomerId, opt
            //     => opt.MapFrom(src => src.Customer.Id))
            // .ForMember(dest => dest.WaiterId, opt
            //     => opt.MapFrom(src => src.Waiter.Id))
            // .ReverseMap();
        }
    }
}