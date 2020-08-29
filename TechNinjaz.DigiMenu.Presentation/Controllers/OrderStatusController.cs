using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechNinjaz.DigiMenu.Domain.DTO;
using TechNinjaz.DigiMenu.Presentation.ModelView;
using TechNinjaz.DigiMenu.Service;

namespace TechNinjaz.DigiMenu.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderStatusController : BaseController<OrderStatus,OrderStatusModel>
    {
        public OrderStatusController(IService<OrderStatus> baseService, IMapper mapper) : base(baseService, mapper)
        {
        }
    }
}