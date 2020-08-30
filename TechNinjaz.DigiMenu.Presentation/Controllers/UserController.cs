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
    public class UserController : CustomBaseController<User,UserModel,UserService>
    {
        
        public UserController(UserService baseService, IMapper mapper) : base(baseService, mapper)
        {
        }

        [ActionName("RegisterUser")]
        public override Task<UserModel> Create(UserModel entity)
        {
            return base.Create(entity);
        }

       
    }
}