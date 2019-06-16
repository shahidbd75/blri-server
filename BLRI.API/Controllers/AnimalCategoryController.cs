using System;
using BLRI.Manager.Interfaces.Core;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BLRI.Common.Enum;
using BLRI.ViewModel.LookUp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BLRI.API.Controllers
{
    [Route("api/[controller]")]
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
            catch (Exception e)
            {
                BadRequest();
            }

            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
