using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TechNinjaz.DigiMenu.Presentation.Controllers
{
    public abstract class CustomBaseController<T> :ControllerBase where T : class
    {
        
        [HttpPost("[action]")]
        public abstract Task<T> Create([FromBody] T entity);
        
        [HttpPost("[action]")]
        public abstract Task<T> Update([FromBody] T entity);

        [HttpGet("[action]/{id}")]
        public abstract Task<T> GetById(int id);

        [HttpGet("[action]")]
        public abstract Task<IReadOnlyList<T>> GetAll();
    }
}