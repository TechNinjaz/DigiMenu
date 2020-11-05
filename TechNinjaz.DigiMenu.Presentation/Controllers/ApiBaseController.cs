using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace TechNinjaz.DigiMenu.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Produces(MediaTypeNames.Application.Json)]
    public abstract class ApiBaseController : ControllerBase
    {
        
    }
}