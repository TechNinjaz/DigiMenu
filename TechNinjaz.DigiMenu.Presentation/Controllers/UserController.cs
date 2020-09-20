using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechNinjaz.DigiMenu.Core.Entities;
using TechNinjaz.DigiMenu.Core.Interfaces;
using TechNinjaz.DigiMenu.Presentation.ModelView;

namespace TechNinjaz.DigiMenu.Presentation.Controllers
{
   
    public class UserController : BaseApiController<UserModel>
    {
        private readonly IGenericService<User> _service;
        private readonly IMapper _mapper;

        public UserController(IGenericService<User> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

   
        [ActionName("RegisterUser")]
        public override async Task<UserModel> Create(UserModel entity)
        {
            var user = await MapUserAsync(entity);
            return _mapper.Map<UserModel>(user);
        }

        public override async Task<UserModel> Update(UserModel entity)
        {
            var user = await MapUserAsync(entity, true);
            return _mapper.Map<UserModel>(user);
        }

   
        public override async Task<UserModel> GetById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            return _mapper.Map<UserModel>(user);
        }

        public override async Task<IReadOnlyList<UserModel>> GetAll()
        {
            var users = await _service.GetAllAsync();
            return _mapper.Map<IReadOnlyList<UserModel>>(users);
        }

        private async Task<User> MapUserAsync(UserModel model, bool isUpdate=false)
        { 
            var user = _mapper.Map<User>(model); 
            return  isUpdate ? await _service.UpdateAsync(user) : await _service.SaveAsync(user);
        }
    }
}