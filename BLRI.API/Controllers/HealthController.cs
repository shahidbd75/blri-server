using BLRI.Manager.Interfaces.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using BLRI.ViewModel.Health;
using Microsoft.AspNetCore.Authorization;


namespace BLRI.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class HealthController : BaseApiController
    {
        public HealthController(IServiceUnitOfWork serviceUnitOfWork) : base(serviceUnitOfWork)
        {

        }

        // GET: api/<controller>
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var list =  ServiceUnitOfWork.HealthManager.GetAll().ToList();
            return Ok(list);
        }

        // GET: api/<controller>
        [HttpGet("getAllBy")]
        public IActionResult GetAllBy(HealthViewModel healthViewModel)
        {
            var list = ServiceUnitOfWork.HealthManager.GetAll();
            return Ok(list);
        }

        // GET api/<controller>/5
        [HttpGet("getById/{id}")]
        public IActionResult Get(Guid id)
        {
            var liveWeight = ServiceUnitOfWork.HealthManager.Get(id);
            if (liveWeight == null)
            {
                return NoContent();
            }
            return Ok(liveWeight);
        }

        // POST api/<controller>
        [HttpPost("add")]
        public IActionResult Post([FromBody]HealthViewModel healthViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var reasonCode = ServiceUnitOfWork.HealthManager.Add(healthViewModel);
                return StatusCode((int)reasonCode);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("update/{id}")]
        public IActionResult Put(Guid id, [FromBody]HealthViewModel healthViewModel)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Please provide Animal Id");
            }

            if (ServiceUnitOfWork.AnimalManager.Get(id) != null)
            {
                var reasonCode = ServiceUnitOfWork.HealthManager.Update(healthViewModel);
                return StatusCode((int) reasonCode);
            }

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("deleteById/{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            try
            {
                var reasonCode = ServiceUnitOfWork.HealthManager.Delete(id);
                return Ok((int)reasonCode);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("getHealthYieldBy/{animalId}")]
        public IActionResult GetHealthByAnimalId(Guid animalId)
        {
            try
            {
                if (animalId != Guid.Empty)
                {
                    var list = ServiceUnitOfWork.HealthManager.GetHealthByAnimalId(animalId).ToList();
                    return Ok(list);
                }

            }
            catch
            {
                return StatusCode(500);
            }
            return NoContent();
        }
    }
}
