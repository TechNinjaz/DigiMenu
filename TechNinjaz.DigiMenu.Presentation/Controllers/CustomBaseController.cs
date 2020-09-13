using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechNinjaz.DigiMenu.Domain.@interface;

namespace TechNinjaz.DigiMenu.Presentation.Controllers
{
    public abstract class CustomBaseController<T> : ControllerBase  where T : class
    {
        public readonly IMapper Mapper;

        public CustomBaseController(IMapper mapper)
        {
            Mapper = mapper;
        }
        
        [HttpPost]
        [Route("[action]")]
        public abstract Task<T> Create([FromBody] T entity);
        
        [HttpPost]
        [Route("[action]")]
        public abstract Task<T> Update([FromBody] T entity);

        [HttpGet]
        [Route("[action]")]
        public abstract Task<T> GetById(int id);

        [HttpGet]
        [Route("[action]")]
        public abstract Task<IEnumerable<T>> GetAll();
    }
}