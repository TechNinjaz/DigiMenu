using AutoMapper;
using TechNinjaz.DigiMenu.Domain.DTO;
using TechNinjaz.DigiMenu.Presentation.ModelView;

namespace TechNinjaz.DigiMenu.Presentation.MapperFactory
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserModel>().ReverseMap();
            // CreateMap<Shift, ShiftModel>().ReverseMap();
            // CreateMap<Menu, MenuModel>().ReverseMap();
            // CreateMap<Order, OrderModel>().ReverseMap();
            // CreateMap<MenuItem, MenuItemModel>().ReverseMap();
            // CreateMap<StaffUser, StaffUserModel>().ReverseMap();
            // CreateMap<OrderStatus, OrderStatusModel>().ReverseMap();
            // CreateMap<SittingTable, SittingTableModel>().ReverseMap();
            // CreateMap<PaymentMethod, PaymentMethodModel>().ReverseMap(); 
        }
    }
}