using System;
using System.Collections.Generic;
using System.Net.Mime;
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
    [Produces(MediaTypeNames.Application.Json)]
    public class UserController : CustomBaseController<UserModel>
    {
        private readonly UserService _userService;
        
        public UserController(UserService userService, IMapper mapper) : base(mapper)
        {
            _userService = userService;
        }

        [ActionName("RegisterUser")]
        public override async Task<UserModel> Create(UserModel entity)
        {
            var user = await MapUser(entity);
            return Mapper.Map<UserModel>(user);
        }

        public override async Task<UserModel> Update(UserModel entity)
        {
            var user = await MapUser(entity);
            return Mapper.Map<UserModel>(user);
        }

        public override async Task<UserModel> GetById(int id)
        {
            var user = await _userService.GetById(id);
            return Mapper.Map<UserModel>(user);
        }

        public override async Task<IEnumerable<UserModel>> GetAll()
        {
            var users = await _userService.GetAll();
            return Mapper.Map<IEnumerable<UserModel>>(users);
        }

        private async Task<User> MapUser(UserModel model)
        {
            var user = Mapper.Map<User>(model);
            return await _userService.Save(user);
            
        }
    }
}