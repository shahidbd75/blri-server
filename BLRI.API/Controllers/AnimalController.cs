using System;
using System.Collections.Generic;
using BLRI.Manager.Interfaces.Core;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BLRI.Common.Enum;
using BLRI.ViewModel.Animals;
using BLRI.ViewModel.LookUp;
using Microsoft.AspNetCore.Authorization;

namespace BLRI.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class AnimalController : BaseApiController
    {
        public AnimalController(IServiceUnitOfWork serviceUnitOfWork) : base(serviceUnitOfWork)
        {

        }

        // GET: api/<controller>
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var list =  ServiceUnitOfWork.AnimalManager.GetAll().ToList();
            return Ok(list);
        }

        // GET: api/<controller>
        [HttpGet("getAllBy")]
        public IActionResult GetAll(AnimalViewModel animalViewModel)
        {
            var list = ServiceUnitOfWork.AnimalManager.GetAnimalListBy();
            return Ok(list);
        }

        // GET api/<controller>/5
        [HttpGet("getById/{id}")]
        public IActionResult Get(Guid id)
        {
            var animalCategory = ServiceUnitOfWork.AnimalManager.Get(id);
            if (animalCategory == null)
            {
                return NoContent();
            }
            return Ok(animalCategory);
        }

        // POST api/<controller>
        [HttpPost("add")]
        public IActionResult Post([FromBody]AnimalViewModel animalViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var reasonCode = ServiceUnitOfWork.AnimalManager.Add(animalViewModel);
                return StatusCode((int)reasonCode);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("update/{id}")]
        public IActionResult Put(Guid id, [FromBody]AnimalViewModel animalViewModel)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Please provide Animal Id");
            }

            if (ServiceUnitOfWork.AnimalManager.Get(id) != null)
            {
                var reasonCode = ServiceUnitOfWork.AnimalManager.Update(animalViewModel);
                return Ok((int) reasonCode);
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
                var reasonCode = ServiceUnitOfWork.AnimalManager.Delete(id);
                return Ok((int)reasonCode);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("getAnimalDropdown/{categoryId}")]
        public IActionResult GetAnimalByCategoryId(int categoryId)
        {
            List<DropdownViewModel<Guid>> animalList;
            try
            {
                if (categoryId > 0)
                {
                    animalList = ServiceUnitOfWork.AnimalManager.GetAnimalsDropdown(categoryId).ToList();
                }
                else
                {
                    animalList = ServiceUnitOfWork.AnimalManager.GetAll().Select(a => new DropdownViewModel<Guid>()
                    {
                        Id = a.Id,
                        Name = a.AIdNew
                    }).ToList();
                }

            }
            catch
            {
                return StatusCode(500);
            }
            if (animalList.Any())
            {
                return Ok(animalList);
            }
            return NoContent();
        }

        [HttpGet("getAllInfoById/{id}")]
        public IActionResult GetAnimalInfo(Guid id)
        {
            var animalCategory = ServiceUnitOfWork.AnimalManager.GetAllInfoById(id);
            if (animalCategory == null)
            {
                return NoContent();
            }
            return Ok(animalCategory);
        }

        [HttpGet("getDamAndSireByCategoryId/{categoryId}/{genderId}")]
        public IActionResult GetDamSireByCategoryId(int categoryId, int genderId)
        {
            List<DropdownViewModel<Guid>> animalList = new List<DropdownViewModel<Guid>>();
            try
            {
                if (categoryId > 0)
                {
                    animalList = ServiceUnitOfWork.AnimalManager.GetDamSireDropdownByCategory(categoryId,genderId).ToList();
                    return Ok(animalList);
                }
            }
            catch
            {
                return StatusCode(500);
            }
            return Ok(animalList);
        }

        [HttpGet("autoGenerateAnimalId/{prefix}")]
        public IActionResult GetAnimalIdNew(string prefix)
        {
            string idNew = "";
            try
            {
                idNew = ServiceUnitOfWork.AnimalManager.GetAutogeneratedAnimalId(prefix);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return Ok(new {autoId = idNew});
        }
    }
}
