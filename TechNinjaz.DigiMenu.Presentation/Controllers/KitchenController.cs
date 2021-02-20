using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechNinjaz.DigiMenu.Core.Entities.OrderEntities;
using TechNinjaz.DigiMenu.Core.Interfaces;
using TechNinjaz.DigiMenu.Presentation.ModelView;

namespace TechNinjaz.DigiMenu.Presentation.Controllers
{
    
    //[Authorize]
    public class KitchenController : ApiBaseController
    {
        private readonly IGenericService<Order> _kitchenService;
        private readonly IMapper _mapper;

        public KitchenController(IGenericService<Order> kitchenService, IMapper mapper)
        {
            _kitchenService = kitchenService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IReadOnlyList<OrderModel>> GetAllOrders()
        {
            var orders = await _kitchenService.GetAllAsync();
            return _mapper.Map<IReadOnlyList<OrderModel>>(orders.OrderByDescending(order => order.CreatedAt.Date == DateTime.Now.Date));
        }

    }
}
