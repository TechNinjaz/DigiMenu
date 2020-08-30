using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechNinjaz.DigiMenu.Domain.@interface;
using TechNinjaz.DigiMenu.Service;
using TechNinjaz.DigiMenu.Service.Interface;

namespace TechNinjaz.DigiMenu.Presentation.Controllers
{
    public class CustomBaseController<T, TView,TService> : ControllerBase  where T : class, IBaseEntity 
        where TView : class 
        where TService : class, IGenericService<T>
    {
        private readonly TService _baseService;
        private readonly IMapper _mapper;

        public CustomBaseController(TService baseService, IMapper mapper)
        {
            _baseService = baseService;
            _mapper = mapper;
        }
        
        [HttpPost]
        [Route("[action]")]
        // [ValidateAntiForgeryToken]
        public virtual async Task<TView> Create(TView entity)
        {
            var obj = _mapper.Map<T>(entity);
            obj = await _baseService.Save(obj);
            return _mapper.Map<TView>(obj);
        }
        
        [HttpPost]
        [Route("[action]")]
        [ValidateAntiForgeryToken]
        public virtual async Task<TView> Update( TView entity)
        {
            var obj = _mapper.Map<T>(entity);
            obj = await _baseService.Update(obj);
            return _mapper.Map<TView>(obj);
        }
        
        [HttpGet]
        [Route("[action]")]
        public virtual async  Task<TView> GetById(Guid id)
        {
            var obj = await _baseService.GetById(id);
            return _mapper.Map<TView>(obj);
        }

        [HttpGet]
        [Route("[action]")]
        public virtual async Task<IEnumerable<TView>> GetAll()
        {
            var objs = await _baseService.GetAll();
            return _mapper.Map<IEnumerable<TView>>(objs);
        }
    }
}