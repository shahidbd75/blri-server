using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using BLRI.API.Helper;
using BLRI.Common.Enum;
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

        /// <summary>
        /// Response Result
        /// </summary>
        /// <param name="reasonCode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        protected IActionResult ResponseResult(ReasonCode reasonCode, string message)
        {
            return new ObjectResult(new Response
            {
                Code = reasonCode,
                IsSuccess = true,
                Message = message
            });
        }
        protected IActionResult ErrorResponseResult(ReasonCode reasonCode, string message)
        {
            return new ObjectResult(new Response
            {
                Code = reasonCode,
                IsSuccess = false,
                Message = message
            });
        }

        protected IActionResult ResponseResult<T>(ReasonCode reasonCode, string message, T data) where T: class
        {
            return new ObjectResult(new SingleResponse<T>()
            {
                Code = reasonCode,
                IsSuccess = true,
                Message = message,
                Model = data
            });
        }
        protected IActionResult ResponseResult<T>(ReasonCode reasonCode, string message, IList<T> data) where T : class
        {
            return new ObjectResult(new ListResponse<T>()
            {
                Code = reasonCode,
                IsSuccess = true,
                Message = message,
                Model = data
            });
        }
    }
}