using BLRI.Manager.Interfaces.Core;
using BLRI.ViewModel.Growth;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace BLRI.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class GrowthController : BaseApiController
    {
        public GrowthController(IServiceUnitOfWork serviceUnitOfWork) : base(serviceUnitOfWork)
        {

        }

        // GET: api/<controller>
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var list =  ServiceUnitOfWork.GrowthManager.GetAll().ToList();
            return Ok(list);
        }

        // GET: api/<controller>
        [HttpGet("getAllBy")]
        public IActionResult GetAll(GrowthViewModel growthViewModel)
        {
            var list = ServiceUnitOfWork.GrowthManager.GetAll();
            return Ok(list);
        }

        // GET api/<controller>/5
        [HttpGet("getById/{id}")]
        public IActionResult Get(Guid id)
        {
            var liveWeight = ServiceUnitOfWork.GrowthManager.Get(id);
            if (liveWeight == null)
            {
                return NoContent();
            }
            return Ok(liveWeight);
        }

        // POST api/<controller>
        [HttpPost("add")]
        public IActionResult Post([FromBody]GrowthViewModel growthViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                growthViewModel.UpdatedByUserId = GetUserId();
                var reasonCode = ServiceUnitOfWork.GrowthManager.Add(growthViewModel);
                return StatusCode((int)reasonCode);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("update/{id}")]
        public IActionResult Put(Guid id, [FromBody]GrowthViewModel growthViewModel)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Please provide Animal Id");
            }

            if (ServiceUnitOfWork.AnimalManager.Get(id) != null)
            {
                growthViewModel.UpdatedByUserId = GetUserId();
                var reasonCode = ServiceUnitOfWork.GrowthManager.Update(growthViewModel);
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
                var reasonCode = ServiceUnitOfWork.GrowthManager.Delete(id);
                return Ok((int)reasonCode);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("getGrowthBy/{animalId}")]
        public IActionResult GetGrowthByAnimalId(Guid animalId)
        {
            try
            {
                if (animalId != Guid.Empty)
                {
                    var list = ServiceUnitOfWork.GrowthManager.GetGrowthByAnimalId(animalId).ToList();
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
