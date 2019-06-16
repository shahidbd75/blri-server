using System;
using System.Linq;
using System.Threading.Tasks;
using BLRI.API.Provider;
using BLRI.Entity.Auth;
using BLRI.Manager.Map;
using BLRI.ViewModel.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BLRI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private ITokenProvider tokenProvider;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ITokenProvider tokenProvider)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenProvider = tokenProvider;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await userManager.FindByNameAsync(loginViewModel.UserName);
            if (user == null)
            {
                return BadRequest("invalid user");
            }

            var userResult = await userManager.CheckPasswordAsync(user, loginViewModel.Password);
            if (userResult)
            {
                return Ok(tokenProvider.GenerateToken(user));
            }

            return NotFound("invalid password");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Registration(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = new User();
            user.UpdateUserModel(userViewModel);

            var identityResult = await userManager.CreateAsync(user, userViewModel.Password);
            if (identityResult.Succeeded)
            {
                return Ok();
            }

            return BadRequest(String.Join("#", identityResult.Errors.Select(x=>x.Description).ToList()));
        }
    }
}