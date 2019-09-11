using BLRI.Manager.Interfaces.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using BLRI.Common.Enum;
using BLRI.ViewModel.BreedingService;
using Microsoft.AspNetCore.Authorization;

namespace BLRI.API.Controllers
{
    [Route("api/[controller]")]
    public class BreedingServiceController : BaseApiController
    {
        public BreedingServiceController(IServiceUnitOfWork serviceUnitOfWork) : base(serviceUnitOfWork)
        {

        }

        // GET: api/<controller>
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var list =  ServiceUnitOfWork.BreedingServiceManager.GetAll().ToList();
            return ResponseResult(ReasonCode.Ok,"", list);
        }

        // GET: api/<controller>
        [HttpGet("getAllBy")]
        public IActionResult GetAllBy(BreedingServiceViewModel breedingViewModel)
        {
            var list = ServiceUnitOfWork.BreedingServiceManager.GetAll();
            return Ok(list);
        }

        // GET api/<controller>/5
        [HttpGet("getById/{id}")]
        public IActionResult Get(Guid id)
        {
            var liveWeight = ServiceUnitOfWork.BreedingServiceManager.Get(id);
            if (liveWeight == null)
            {
                return NoContent();
            }
            return Ok(liveWeight);
        }

        // POST api/<controller>
        [HttpPost("add")]
        public IActionResult Post([FromBody]BreedingServiceViewModel breedingViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                if (ServiceUnitOfWork.BreedingServiceManager.IsExistBreedingServiceByParity(breedingViewModel.AnimalId,breedingViewModel.Parity))
                {
                    return ErrorResponseResult(ReasonCode.AlreadyExist, "Already exist data for this parity");
                }
                breedingViewModel.UpdatedByUserId = GetUserId();
                var reasonCode = ServiceUnitOfWork.BreedingServiceManager.Add(breedingViewModel);
                return ResponseResult(reasonCode, "Created Successfully");

            }
            catch(Exception ex)
            {
                return ErrorResponseResult(ReasonCode.InternalServerError,ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("update/{id}")]
        public IActionResult Put(Guid id, [FromBody]BreedingServiceViewModel breedingViewModel)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Please provide Animal Id");
            }

            if (ServiceUnitOfWork.BreedingServiceManager.Get(id) != null)
            {
                breedingViewModel.UpdatedByUserId = GetUserId();
                if (ServiceUnitOfWork.BreedingServiceManager.IsExistBreedingServiceByParityOther(id,breedingViewModel.AnimalId,breedingViewModel.Parity))
                {
                    return ErrorResponseResult(ReasonCode.AlreadyExist, "Same Parity already exist");
                }
                var reasonCode = ServiceUnitOfWork.BreedingServiceManager.Update(breedingViewModel);
                return ResponseResult(reasonCode, "Updated Successfully");
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
                var reasonCode = ServiceUnitOfWork.BreedingServiceManager.Delete(id);
                return Ok((int)reasonCode);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("getBreedHistoryBy/{animalId}")]
        public IActionResult GetBreedingByAnimalId(Guid animalId)
        {
            try
            {
                if (animalId != Guid.Empty)
                {
                    var list = ServiceUnitOfWork.BreedingServiceManager.GetBreedingServiceByAnimalId(animalId).ToList();
                    return ResponseResult(ReasonCode.Ok,"",list);
                }

            }
            catch(Exception e)
            {
                return ErrorResponseResult(ReasonCode.InternalServerError, e.Message);
            }
            return ResponseResult(ReasonCode.NotFound,"No data found");
        }
    }
}
