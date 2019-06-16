using BLRI.Manager.Interfaces.Core;
using Microsoft.AspNetCore.Mvc;

namespace BLRI.API.Controllers
{
    public abstract class BaseApiController : ControllerBase
    {
        protected readonly IServiceUnitOfWork ServiceUnitOfWork;

        public BaseApiController(IServiceUnitOfWork serviceUnitOfWork)
        {
            ServiceUnitOfWork = serviceUnitOfWork;
        }
    }
}