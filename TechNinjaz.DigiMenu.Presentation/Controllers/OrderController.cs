using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechNinjaz.DigiMenu.Core.Entities;
using TechNinjaz.DigiMenu.Core.Entities.OrderEntities;
using TechNinjaz.DigiMenu.Core.Interfaces;
using TechNinjaz.DigiMenu.Presentation.ModelView;

namespace TechNinjaz.DigiMenu.Presentation.Controllers
{
    public class OrderController : ApiBaseController
    {
        private readonly IGenericService<Order> _orderService;
        private readonly IMapper _mapper;

        public OrderController(IGenericService<Order> orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public  async Task<OrderModel> Create(OrderModel entity)
        {
            var order = await MapOrderAsync(entity);
            return _mapper.Map<OrderModel>(order);
        }
        [HttpPost]
        public  async Task<OrderModel> Update(OrderModel entity)
        {
            var order = await MapOrderAsync(entity, true);
            return _mapper.Map<OrderModel>(order);
        }

        [HttpGet("{id}")]
        public async Task<OrderModel> GetById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            return _mapper.Map<OrderModel>(order);
        }
        [HttpGet("{userId}")]

        public async Task<IReadOnlyList<OrderModel>> GetAllUserOrders(int userId)
        {
            var orders = await _orderService.GetAllAsync();
            return _mapper.Map<IReadOnlyList<OrderModel>>(orders);
        }

        private async Task<Order> MapOrderAsync(OrderModel model, bool isUpdate = false)
        {
            var user = _mapper.Map<Order>(model);
            return isUpdate ? await _orderService.UpdateAsync(user) : await _orderService.SaveAsync(user);
        }
    }
}