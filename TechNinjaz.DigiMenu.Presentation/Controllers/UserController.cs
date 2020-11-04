using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechNinjaz.DigiMenu.Core.Entities;
using TechNinjaz.DigiMenu.Core.Entities.Identity;
using TechNinjaz.DigiMenu.Core.Interfaces;
using TechNinjaz.DigiMenu.Presentation.ModelView;

namespace TechNinjaz.DigiMenu.Presentation.Controllers
{
    public class UserController : ApiBaseController
    {
        private readonly IGenericService<UserProfile> _service;
        private readonly IMapper _mapper;

        public UserController(IGenericService<UserProfile> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<UserProfileModel> Create(UserProfileModel entity)
        {
            var user = await MapUserAsync(entity);
            return _mapper.Map<UserProfileModel>(user);
        }

        [HttpPost]
        public async Task<UserProfileModel> Update(UserProfileModel entity)
        {
            var user = await MapUserAsync(entity, true);
            return _mapper.Map<UserProfileModel>(user);
        }

        [HttpGet("{id}")]
        public async Task<UserProfileModel> GetById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            return _mapper.Map<UserProfileModel>(user);
        }

        [HttpGet]
        public async Task<IReadOnlyList<UserProfileModel>> GetAll()
        {
            var users = await _service.GetAllAsync();
            return _mapper.Map<IReadOnlyList<UserProfileModel>>(users);
        }

        private async Task<UserProfile> MapUserAsync(UserProfileModel profileModel, bool isUpdate = false)
        {
            var user = _mapper.Map<UserProfile>(profileModel);
            return isUpdate ? await _service.UpdateAsync(user) : await _service.SaveAsync(user);
        }
    }
}