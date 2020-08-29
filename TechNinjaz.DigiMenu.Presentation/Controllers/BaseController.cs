using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechNinjaz.DigiMenu.Domain.@interface;
using TechNinjaz.DigiMenu.Service;

namespace TechNinjaz.DigiMenu.Presentation.Controllers
{
    public class BaseController<T, IView> : ControllerBase  where T : class, IBaseEntity where IView : class
    {
        private readonly IService<T> _baseService;
        private readonly IMapper _mapper;

        public BaseController(IService<T> baseService, IMapper mapper)
        {
            _baseService = baseService;
            _mapper = mapper;
        }
        
        [HttpPost]
        [Route("[action]")]
        public  virtual async Task<IView> create([FromForm] IView entity)
        {
            var obj = _mapper.Map<T>(entity);
            obj = await _baseService.Save(obj);
            return _mapper.Map<IView>(obj);
        }
        
        [HttpPost]
        [Route("[action]")]
        public virtual async Task<IView> Update([FromForm] IView entity)
        {
            var obj = _mapper.Map<T>(entity);
            obj = await _baseService.Update(obj);
            return _mapper.Map<IView>(obj);
        }
        
        [HttpGet]
        [Route("[action]")]
        public virtual async  Task<IView> GetById(Guid id)
        {
            var obj = await _baseService.GetById(id);
            return _mapper.Map<IView>(obj);
        }

        [HttpGet]
        [Route("[action]")]
        public virtual async Task<IEnumerable<IView>> GetAll()
        {
            var objs = await _baseService.GetAll();
            return _mapper.Map<IEnumerable<IView>>(objs);
        }
    }
}