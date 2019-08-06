using System;
using BLRI.Manager.Interfaces.Core;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BLRI.Common.Enum;
using BLRI.ViewModel.Units;
using Microsoft.AspNetCore.Authorization;

namespace BLRI.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class WeightUnitsController : BaseApiController
    {
        public WeightUnitsController(IServiceUnitOfWork serviceUnitOfWork) : base(serviceUnitOfWork)
        {

        }

        // GET: api/<controller>
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var list =  ServiceUnitOfWork.WeightUnitsManager.GetAll().ToList();
            return Ok(list);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var biometricUnits = ServiceUnitOfWork.WeightUnitsManager.Get(id);

            return Ok(biometricUnits);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]WeightUnitViewModel weightUnitViewModel)
        {
            try
            {
                return Ok(ServiceUnitOfWork.WeightUnitsManager.Add(weightUnitViewModel));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]WeightUnitViewModel viewModel)
        {
            try
            {
                var status = ServiceUnitOfWork.WeightUnitsManager.Update(viewModel);
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
                var status = ServiceUnitOfWork.WeightUnitsManager.Delete(id);
                return status == ReasonCode.Deleted ? Ok() : StatusCode(500);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
