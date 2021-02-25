using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechNinjaz.DigiMenu.Core.Entities.OrderEntities;
using TechNinjaz.DigiMenu.Core.Interfaces;

namespace TechNinjaz.DigiMenu.Presentation.Controllers
{
    public class OrderStatusController : ApiBaseController
    {
        private readonly IGenericService<OrderStatus> _orderStatusService;

        public OrderStatusController(IGenericService<OrderStatus> orderStatusService)
        {
            _orderStatusService = orderStatusService;
        }

        [HttpPost]
        public async Task<OrderStatus> Create(OrderStatus entity)
        {
            return await _orderStatusService.SaveAsync(entity);
        }

        [HttpPost]
        public async Task<OrderStatus> Update(OrderStatus entity)
        {
            return await _orderStatusService.UpdateAsync(entity);
        }

        [HttpGet("{id}")]
        public async Task<OrderStatus> GetById(int id)
        {
            return await _orderStatusService.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<IReadOnlyList<OrderStatus>> GetAll()
        {
            return await _orderStatusService.GetAllAsync();
        }
    }
}