using System;
using System.Linq;
using System.Security.Claims;
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
        private readonly UserManager<User> _userManager;
        private readonly ITokenProvider _tokenProvider;
        public AccountController(UserManager<User> userManager, ITokenProvider tokenProvider)
        {
            this._userManager = userManager;
            this._tokenProvider = tokenProvider;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
            if (user == null)
            {
                return BadRequest("invalid user");
            }

            var userResult = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
            if (userResult)
            {
                ClaimsIdentity claims = new ClaimsIdentity("token");
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier,user.Id));
                claims.AddClaim(new Claim(ClaimTypes.GivenName,user.UserName));
                return Ok(new { token = _tokenProvider.GenerateToken(user)});
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

            var identityResult = await _userManager.CreateAsync(user, userViewModel.Password);
            if (identityResult.Succeeded)
            {
                return Ok();
            }

            return BadRequest(String.Join("#", identityResult.Errors.Select(x=>x.Description).ToList()));
        }
    }
}