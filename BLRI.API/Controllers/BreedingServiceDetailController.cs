using BLRI.Manager.Interfaces.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using BLRI.Common.Enum;
using BLRI.ViewModel.BreedingServiceDetail;
using Microsoft.AspNetCore.Authorization;

namespace BLRI.API.Controllers
{
    [Route("api/[controller]")]
    public class BreedingServiceDetailController : BaseApiController
    {
        public BreedingServiceDetailController(IServiceUnitOfWork serviceUnitOfWork) : base(serviceUnitOfWork)
        {

        }

        // GET: api/<controller>
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var list =  ServiceUnitOfWork.BreedingServiceDetailManager.GetAll().ToList();
            return ResponseResult(ReasonCode.Ok,"", list);
        }

        // GET: api/<controller>
        [HttpGet("getAllBy")]
        public IActionResult GetAllBy(BreedingServiceDetailViewModel breedingViewModel)
        {
            var list = ServiceUnitOfWork.BreedingServiceDetailManager.GetAll();
            return ResponseResult(ReasonCode.Ok,"",list);
        }

        // GET api/<controller>/5
        [HttpGet("getById/{id}")]
        public IActionResult Get(Guid id)
        {
            var breedingService = ServiceUnitOfWork.BreedingServiceDetailManager.Get(id);
            if (breedingService == null)
            {
                return ResponseResult(ReasonCode.NoContent,"Data not found");
            }
            return ResponseResult(ReasonCode.Ok,"",breedingService);
        }

        // POST api/<controller>
        [HttpPost("add")]
        public IActionResult Post([FromBody]BreedingServiceDetailViewModel breedingViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                breedingViewModel.UpdatedByUserId = GetUserId();
                var reasonCode = ServiceUnitOfWork.BreedingServiceDetailManager.Add(breedingViewModel);
                return ResponseResult(reasonCode, "Created Successfully");

            }
            catch(Exception ex)
            {
                return ErrorResponseResult(ReasonCode.InternalServerError,ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("update/{id}")]
        public IActionResult Put(Guid id, [FromBody]BreedingServiceDetailViewModel breedingViewModel)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Please provide Animal Id");
            }

            if (ServiceUnitOfWork.BreedingServiceDetailManager.Get(id) != null)
            {
                breedingViewModel.UpdatedByUserId = GetUserId();
                var reasonCode = ServiceUnitOfWork.BreedingServiceDetailManager.Update(breedingViewModel);
                return ResponseResult(reasonCode, "Updated Successfully");
            }

            return ErrorResponseResult(ReasonCode.NoContent,"No content for update");
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
                var reasonCode = ServiceUnitOfWork.BreedingServiceDetailManager.Delete(id);
                return ResponseResult(reasonCode,"");
            }
            catch (Exception e)
            {
                return ErrorResponseResult(ReasonCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("getBreedServiceListByServiceId/{serviceId}")]
        public IActionResult GetBreedingServiceDetailByServiceId(Guid serviceId)
        {
            try
            {
                if (serviceId != Guid.Empty)
                {
                    var list = ServiceUnitOfWork.BreedingServiceDetailManager.GetBreedingServiceDetailById(serviceId).ToList();
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
