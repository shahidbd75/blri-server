using System;
using BLRI.Manager.Interfaces.Core;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BLRI.ViewModel.Biometric;
using Microsoft.AspNetCore.Authorization;

namespace BLRI.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class BiometricController : BaseApiController
    {
        public BiometricController(IServiceUnitOfWork serviceUnitOfWork) : base(serviceUnitOfWork)
        {

        }

        // GET: api/<controller>
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var list =  ServiceUnitOfWork.BiometricManager.GetAll().ToList();
            return Ok(list);
        }

        // GET: api/<controller>
        [HttpGet("getAllBy")]
        public IActionResult GetAll(BiometricViewModel animalViewModel)
        {
            var list = ServiceUnitOfWork.BiometricManager.GetAll();
            return Ok(list);
        }

        // GET api/<controller>/5
        [HttpGet("getById/{id}")]
        public IActionResult Get(Guid id)
        {
            var biometric = ServiceUnitOfWork.BiometricManager.GetBiometricById(id);
            if (biometric == null)
            {
                return NoContent();
            }
            return Ok(biometric);
        }

        // POST api/<controller>
        [HttpPost("add")]
        public IActionResult Post([FromBody]BiometricViewModel biometricViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var reasonCode = ServiceUnitOfWork.BiometricManager.Add(biometricViewModel);
                return StatusCode((int)reasonCode);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("update/{id}")]
        public IActionResult Put(Guid id, [FromBody]BiometricViewModel biometricViewModel)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Please provide Animal Id");
            }

            if (ServiceUnitOfWork.AnimalManager.Get(id) != null)
            {
                var reasonCode = ServiceUnitOfWork.BiometricManager.Update(biometricViewModel);
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
                var reasonCode = ServiceUnitOfWork.BiometricManager.Delete(id);
                return Ok((int)reasonCode);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("getBiometricBy/{animalId}")]
        public IActionResult GetBiometricByAnimalId(Guid animalId)
        {
            try
            {
                if (animalId != Guid.Empty)
                {
                    var list = ServiceUnitOfWork.BiometricManager.GetBiometricByAnimalId(animalId).ToList();
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
