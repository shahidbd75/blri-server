using System.Linq;
using System.Security.Claims;
using BLRI.Manager.Interfaces.Core;
using Microsoft.AspNetCore.Mvc;

namespace BLRI.API.Controllers
{
    public abstract class BaseApiController : ControllerBase
    {
        protected readonly IServiceUnitOfWork ServiceUnitOfWork;

        protected BaseApiController(IServiceUnitOfWork serviceUnitOfWork)
        {
            ServiceUnitOfWork = serviceUnitOfWork;
        }
        protected string GetUserId()
        {
            var identity = User.Identity as ClaimsIdentity;
            return identity?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}