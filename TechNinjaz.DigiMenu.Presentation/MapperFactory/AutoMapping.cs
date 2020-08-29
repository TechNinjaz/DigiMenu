using AutoMapper;
using TechNinjaz.DigiMenu.Domain.DTO;
using TechNinjaz.DigiMenu.Presentation.ModelView;

namespace TechNinjaz.DigiMenu.Presentation.MapperFactory
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserModel>(); 
            CreateMap<OrderStatus, OrderStatusModel>(); 
        }
    }
}