using TechNinjaz.DigiMenu.Domain.DTO;
using TechNinjaz.DigiMenu.Repository;
using TechNinjaz.DigiMenu.Service.Interface;

namespace TechNinjaz.DigiMenu.Service
{
    public class OrderService : GenericService<Order>
    {
        public OrderService(IRepository<Order> repository) : base(repository)
        {
        }
    }
}