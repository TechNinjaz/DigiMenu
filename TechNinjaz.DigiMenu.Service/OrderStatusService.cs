using TechNinjaz.DigiMenu.Domain.DTO;
using TechNinjaz.DigiMenu.Repository;
using TechNinjaz.DigiMenu.Service.Interface;

namespace TechNinjaz.DigiMenu.Service
{
    public class OrderStatusService : GenericService<OrderStatus>
    {
        public OrderStatusService(IRepository<OrderStatus> repository) : base(repository)
        {
        }
    }
}