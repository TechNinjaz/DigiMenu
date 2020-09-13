using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechNinjaz.DigiMenu.Domain.DTO;
using TechNinjaz.DigiMenu.Service;

namespace TechNinjaz.DigiMenu.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class OrderStatusController : CustomBaseController<OrderStatus>
    {
        private readonly OrderStatusService _orderStatusService;
        public OrderStatusController(OrderStatusService orderStatusService, IMapper mapper) : base(mapper)
        {
            _orderStatusService = orderStatusService;
        }

        public override async Task<OrderStatus> Create(OrderStatus entity)
        {
            return await _orderStatusService.Save(entity);
        }

        public override async Task<OrderStatus> Update(OrderStatus entity)
        {
            return await _orderStatusService.Update(entity);
        }

        public override async Task<OrderStatus> GetById(int id)
        {
            return await _orderStatusService.GetById(id);
        }

        public override async Task<IEnumerable<OrderStatus>> GetAll()
        {
            return await _orderStatusService.GetAll();
        }
    }
}