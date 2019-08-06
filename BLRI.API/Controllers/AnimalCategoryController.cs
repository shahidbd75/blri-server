using System;
using BLRI.Manager.Interfaces.Core;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BLRI.Common.Enum;
using BLRI.ViewModel.Animals;
using Microsoft.AspNetCore.Authorization;

namespace BLRI.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class AnimalCategoryController : BaseApiController
    {
        public AnimalCategoryController(IServiceUnitOfWork serviceUnitOfWork) : base(serviceUnitOfWork)
        {

        }

        // GET: api/<controller>
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var list =  ServiceUnitOfWork.AnimalCategoryManager.GetAll().ToList();
            return Ok(list);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var animalCategory = ServiceUnitOfWork.AnimalCategoryManager.Get(id);

            return Ok(animalCategory);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]AnimalCategoryViewModel animalCategoryViewModel)
        {
            try
            {
                return Ok(ServiceUnitOfWork.AnimalCategoryManager.Add(animalCategoryViewModel));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]AnimalCategoryViewModel viewModel)
        {
            try
            {
                var status = ServiceUnitOfWork.AnimalCategoryManager.Update(viewModel);
                return status == ReasonCode.Updated ? Ok() : StatusCode(500);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var status = ServiceUnitOfWork.AnimalCategoryManager.Delete(id);
                return status == ReasonCode.Deleted ? Ok() : StatusCode(500);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
