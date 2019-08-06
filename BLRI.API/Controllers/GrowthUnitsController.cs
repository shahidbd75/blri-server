using System;
using BLRI.Manager.Interfaces.Core;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BLRI.Common.Enum;
using BLRI.ViewModel.Animals;
using BLRI.ViewModel.Units;
using Microsoft.AspNetCore.Authorization;

namespace BLRI.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class GrowthUnitsController : BaseApiController
    {
        public GrowthUnitsController(IServiceUnitOfWork serviceUnitOfWork) : base(serviceUnitOfWork)
        {

        }

        // GET: api/<controller>
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var list =  ServiceUnitOfWork.GrowthUnitsManager.GetAll().ToList();
            return Ok(list);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var biometricUnits = ServiceUnitOfWork.GrowthUnitsManager.Get(id);

            return Ok(biometricUnits);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]GrowthUnitViewModel growthUnitViewModel)
        {
            try
            {
                return Ok(ServiceUnitOfWork.GrowthUnitsManager.Add(growthUnitViewModel));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]GrowthUnitViewModel viewModel)
        {
            try
            {
                var status = ServiceUnitOfWork.GrowthUnitsManager.Update(viewModel);
                return status == ReasonCode.Updated ? Ok() : StatusCode(500);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                var status = ServiceUnitOfWork.GrowthUnitsManager.Delete(id);
                return status == ReasonCode.Deleted ? Ok() : StatusCode(500);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
