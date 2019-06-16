using BLRI.Manager.Interfaces.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace BLRI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropdownController : BaseApiController
    {
        public DropdownController(IServiceUnitOfWork serviceUnitOfWork) : base(serviceUnitOfWork)
        {
        }

        public IActionResult Get()
        {
            var result = ServiceUnitOfWork.DropdownManager.GetBiometricUnitsDropdown();
            return Ok(result);
        }
    }
}