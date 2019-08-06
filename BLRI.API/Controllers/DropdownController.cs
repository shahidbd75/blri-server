using BLRI.Manager.Interfaces.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace BLRI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DropdownController : BaseApiController
    {
        public DropdownController(IServiceUnitOfWork serviceUnitOfWork) : base(serviceUnitOfWork)
        {
        }

        [HttpGet("getBiometricUnits")]
        public IActionResult GetBiometricUnits()
        {
            var result = ServiceUnitOfWork.DropdownManager.GetBiometricUnitsDropdown();
            return Ok(result);
        }

        [HttpGet("getLiveWeightUnits")]
        public IActionResult GetWeightUnitsDropdown()
        {
            var result = ServiceUnitOfWork.DropdownManager.GetWeightUnitsDropdown();
            return Ok(result);
        }
        [HttpGet("getGrowthUnits")]
        public IActionResult GetGrowthUnitsDropdown()
        {
            var result = ServiceUnitOfWork.DropdownManager.GetGrowthUnitsDropdown();
            return Ok(result);
        }

        [HttpGet("getAnimalCategories")]
        public IActionResult GetAnimalCategories()
        {
            var result = ServiceUnitOfWork.DropdownManager.GetAnimalCategoriesDropdown();
            return Ok(result);
        }


        [HttpGet("getAnimalGender")]
        public IActionResult GetAnimalGender()
        {
            var result = ServiceUnitOfWork.DropdownManager.GetGenderDropdown();
            return Ok(result);
        }

        [HttpGet("getGenotypes")]
        public IActionResult GetGenotypes()
        {
            var result = ServiceUnitOfWork.DropdownManager.GetGenotypeDropdown();
            return Ok(result);
        }
    }
}