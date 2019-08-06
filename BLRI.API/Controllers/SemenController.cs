using System;
using BLRI.Manager.Interfaces.Core;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BLRI.ViewModel.Biometric;
using BLRI.ViewModel.Live_Weight;
using BLRI.ViewModel.Semen;
using Microsoft.AspNetCore.Authorization;

namespace BLRI.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class SemenController : BaseApiController
    {
        public SemenController(IServiceUnitOfWork serviceUnitOfWork) : base(serviceUnitOfWork)
        {

        }

        // GET: api/<controller>
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var list =  ServiceUnitOfWork.SemenManager.GetAll().ToList();
            return Ok(list);
        }

        // GET: api/<controller>
        [HttpGet("getAllBy")]
        public IActionResult GetAll(SemenViewModel semenViewModel)
        {
            var list = ServiceUnitOfWork.SemenManager.GetAll();
            return Ok(list);
        }

        // GET api/<controller>/5
        [HttpGet("getById/{id}")]
        public IActionResult Get(Guid id)
        {
            var liveWeight = ServiceUnitOfWork.SemenManager.Get(id);
            if (liveWeight == null)
            {
                return NoContent();
            }
            return Ok(liveWeight);
        }

        // POST api/<controller>
        [HttpPost("add")]
        public IActionResult Post([FromBody]SemenViewModel semenViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var reasonCode = ServiceUnitOfWork.SemenManager.Add(semenViewModel);
                return StatusCode((int)reasonCode);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("update/{id}")]
        public IActionResult Put(Guid id, [FromBody]SemenViewModel semenViewModel)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Please provide Animal Id");
            }

            if (ServiceUnitOfWork.AnimalManager.Get(id) != null)
            {
                var reasonCode = ServiceUnitOfWork.SemenManager.Update(semenViewModel);
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
                var reasonCode = ServiceUnitOfWork.SemenManager.Delete(id);
                return Ok((int)reasonCode);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("getSemenBy/{animalId}")]
        public IActionResult GetSemenInfoByAnimalId(Guid animalId)
        {
            try
            {
                if (animalId != Guid.Empty)
                {
                    var list = ServiceUnitOfWork.SemenManager.GetSemenByAnimalId(animalId).ToList();
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
