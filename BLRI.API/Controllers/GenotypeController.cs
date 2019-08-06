using System;
using BLRI.Manager.Interfaces.Core;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BLRI.ViewModel.Animals;
using Microsoft.AspNetCore.Authorization;

namespace BLRI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenotypeController : BaseApiController
    {
        public GenotypeController(IServiceUnitOfWork serviceUnitOfWork) : base(serviceUnitOfWork)
        {

        }


        [HttpGet("getAll")]
        public IActionResult Get()
        {
            try
            {
                var genotypes = ServiceUnitOfWork.GenotypeManager.GetAll().ToList();
                return Ok(genotypes);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
       
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var genotype = ServiceUnitOfWork.GenotypeManager.Get(id);
            if (genotype == null)
            {
                return NotFound();
            }

            return Ok(genotype);
        }

        // POST api/values
        [HttpPost("add")]
        public IActionResult Post([FromBody] GenotypeViewModel genotypeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var reasonCode = ServiceUnitOfWork.GenotypeManager.Add(genotypeViewModel);
                return Ok((int)reasonCode);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Put(int id, [FromBody]GenotypeViewModel genotypeViewModel)
        {
            if (id < 1)
            {
                return BadRequest("Please provide Id");
            }

            if (ServiceUnitOfWork.GenotypeManager.Get(id) != null)
            {
                var reasonCode = ServiceUnitOfWork.GenotypeManager.Update(genotypeViewModel);
                return Ok((int)reasonCode);
            }

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("deleteById/{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            try
            {
                var reasonCode = ServiceUnitOfWork.GenotypeManager.Delete(id);
                return Ok((int)reasonCode);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
