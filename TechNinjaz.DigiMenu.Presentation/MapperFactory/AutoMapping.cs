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
            
            CreateMap<AuthUser, LoginResponseModel>().ReverseMap();
            CreateMap<RegisterUserModel, AuthUser>()
                .ForMember(dest => dest.DisplayName, opt =>
                    opt.MapFrom(src => src.FistName + " " + src.LastName))
                .ForMember(dest => dest.UserName, opt =>
                    opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Profile, opt =>
                    opt.MapFrom(src => new UserProfile
                    {
                        FistName = src.FistName,
                        LastName = src.LastName,
                    })).ReverseMap();
        }
    }
}