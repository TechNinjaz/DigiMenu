using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechNinjaz.DigiMenu.Core.Entities.Identity;
using TechNinjaz.DigiMenu.Core.Interfaces;
using TechNinjaz.DigiMenu.Presentation.ModelView;

namespace TechNinjaz.DigiMenu.Presentation.Controllers
{
    public class AccountController : ApiBaseController
    {
        private readonly IJwtFactory _jwtFactory;
        private readonly IMapper _mapper;
        private readonly SignInManager<AuthUser> _signInManager;
        private readonly UserManager<AuthUser> _userManager;

        public AccountController(UserManager<AuthUser> userManager,
            SignInManager<AuthUser> signInManager,
            IJwtFactory jwtFactory, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtFactory = jwtFactory;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<LoginResponseModel>> GetCurrentUser()
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            var user = await _userManager.FindByEmailAsync(email);
            return GetLoginResponseModel(user);
        }

        [HttpGet("{email}")]
        [Authorize]
        public async Task<ActionResult<UserProfileModel>> GetUserProfile(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return _mapper.Map<UserProfileModel>(user.Profile);
        }

        [HttpGet]
        public async Task<ActionResult<bool>> EmailExistAsync([FromBody] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        [HttpPost]
        public async Task<ActionResult<LoginResponseModel>> RegisterUser(RegisterUserModel registerUserModel)
        {
            var user = _mapper.Map<AuthUser>(registerUserModel);
            var registeredUser = await _userManager.CreateAsync(user, registerUserModel.Password);
            if (!registeredUser.Succeeded) return BadRequest(registeredUser.Errors.ToString());

            return GetLoginResponseModel(user);
        }

        [HttpPost]
        public async Task<ActionResult<LoginResponseModel>> Login(UserLoginModel userLoginModel)
        {
            var user = await _userManager.FindByEmailAsync(userLoginModel.Email);
            if (user == null) return Unauthorized();
            var isAuth = await _signInManager.CheckPasswordSignInAsync(user, userLoginModel.Password, false);
            if (!isAuth.Succeeded) return Unauthorized();

            return GetLoginResponseModel(user);
        }

        [HttpPost("{email}")]
        public async Task<ActionResult<bool>> Logout(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return Unauthorized();
            await _signInManager.SignOutAsync();
            return true;
        }


        private LoginResponseModel GetLoginResponseModel(AuthUser user)
        {
            var loginResp = _mapper.Map<LoginResponseModel>(user);
            loginResp.Token = _jwtFactory.CreatedToken(user);
            return loginResp;
        }
    }
}