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
        private readonly UserManager<AuthUser> _userManager;
        private readonly SignInManager<AuthUser> _signInManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly IMapper _mapper;

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
        public async Task<ActionResult<LoginResponseModel>> GetCurrentUser()
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            var user = await _userManager.FindByEmailAsync(email);
            return GetLoginResponseModel(user);
        }

        [HttpGet("{email}"), AllowAnonymous]
        public async Task<ActionResult<UserProfileModel>> GetUserProfile(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return _mapper.Map<UserProfileModel>(user.Profile);
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<bool>> EmailExistAsync([FromBody] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<LoginResponseModel>> RegisterUser(RegisterModel registerModel)
        {
            var user = new AuthUser
            {
                DisplayName = registerModel.FistName + " " + registerModel.LastName,
                Email = registerModel.Email,
                UserName = registerModel.Email,
                Profile = new UserProfile
                {
                    FistName = registerModel.FistName,
                    LastName = registerModel.LastName
                }
            };
            var registeredUser = await _userManager.CreateAsync(user, registerModel.Password);
            if (!registeredUser.Succeeded) return BadRequest(registeredUser.Errors.ToString());

            return GetLoginResponseModel(user);
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user == null) return Unauthorized();
            var isAuth = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);
            if (!isAuth.Succeeded) return Unauthorized();

            return GetLoginResponseModel(user);
        }

        private LoginResponseModel GetLoginResponseModel(AuthUser user)
        {
            return new LoginResponseModel
            {
                Email = user.Email,
                Token = _jwtFactory.CreatedToken(user),
                DisplayName = user.DisplayName
            };
        }
    }
}