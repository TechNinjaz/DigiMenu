using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechNinjaz.DigiMenu.Core.Entities;
using TechNinjaz.DigiMenu.Core.Interfaces;

namespace TechNinjaz.DigiMenu.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class OrderStatusController : CustomBaseController<OrderStatus>
    {
        private readonly IGenericService<OrderStatus> _orderStatusService;

        public OrderStatusController(IGenericService<OrderStatus> orderStatusService)
        {
            _orderStatusService = orderStatusService;
        }

        public override async Task<OrderStatus> Create(OrderStatus entity)
        {
            return await _orderStatusService.SaveAsync(entity);
        }

        public override async Task<OrderStatus> Update(OrderStatus entity)
        {
            return await _orderStatusService.UpdateAsync(entity);
        }

        public override async Task<OrderStatus> GetById(int id)
        {
            return await _orderStatusService.GetByIdAsync(id);
        }

        public override async Task<IReadOnlyList<OrderStatus>> GetAll()
        {
            return await _orderStatusService.GetAllAsync();
        }
    }
}