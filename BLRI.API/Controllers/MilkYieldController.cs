using BLRI.Manager.Interfaces.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using BLRI.ViewModel.Milk_Yield;
using Microsoft.AspNetCore.Authorization;

namespace BLRI.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class MilkYieldController : BaseApiController
    {
        public MilkYieldController(IServiceUnitOfWork serviceUnitOfWork) : base(serviceUnitOfWork)
        {

        }

        // GET: api/<controller>
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var list =  ServiceUnitOfWork.MilkYieldManager.GetAll().ToList();
            return Ok(list);
        }

        // GET: api/<controller>
        [HttpGet("getAllBy")]
        public IActionResult GetAllBy(MilkYieldViewModel milkYieldViewModel)
        {
            var list = ServiceUnitOfWork.MilkYieldManager.GetAll();
            return Ok(list);
        }

        // GET api/<controller>/5
        [HttpGet("getById/{id}")]
        public IActionResult Get(Guid id)
        {
            var liveWeight = ServiceUnitOfWork.MilkYieldManager.Get(id);
            if (liveWeight == null)
            {
                return NoContent();
            }
            return Ok(liveWeight);
        }

        // POST api/<controller>
        [HttpPost("add")]
        public IActionResult Post([FromBody]MilkYieldViewModel milkYieldViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                milkYieldViewModel.UpdatedByUserId = GetUserId();
                var reasonCode = ServiceUnitOfWork.MilkYieldManager.Add(milkYieldViewModel);
                return StatusCode((int)reasonCode);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("update/{id}")]
        public IActionResult Put(Guid id, [FromBody]MilkYieldViewModel milkYieldViewModel)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Please provide Animal Id");
            }

            if (ServiceUnitOfWork.AnimalManager.Get(id) != null)
            {
                milkYieldViewModel.UpdatedByUserId = GetUserId();
                var reasonCode = ServiceUnitOfWork.MilkYieldManager.Update(milkYieldViewModel);
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
                var reasonCode = ServiceUnitOfWork.MilkYieldManager.Delete(id);
                return Ok((int)reasonCode);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("getMilkYieldBy/{animalId}")]
        public IActionResult GetMilkYieldByAnimalId(Guid animalId)
        {
            try
            {
                if (animalId != Guid.Empty)
                {
                    var list = ServiceUnitOfWork.MilkYieldManager.GetMilkYieldByAnimalId(animalId).ToList();
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
