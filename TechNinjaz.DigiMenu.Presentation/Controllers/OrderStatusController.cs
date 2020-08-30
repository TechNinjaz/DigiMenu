using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechNinjaz.DigiMenu.Domain.DTO;
using TechNinjaz.DigiMenu.Service;

namespace TechNinjaz.DigiMenu.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class OrderStatusController : CustomBaseController<OrderStatus,OrderStatus, OrderStatusService>
    {
        public OrderStatusController(OrderStatusService baseService, IMapper mapper) : base(baseService, mapper)
        {
        }
    }
}