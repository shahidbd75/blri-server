using BLRI.Manager.Interfaces.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BLRI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : BaseApiController
    {
        public ValuesController(IServiceUnitOfWork serviceUnitOfWork) : base(serviceUnitOfWork)
        {

        }
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(ServiceUnitOfWork.AnimalCategoryManager.GetAll().ToList());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
           // ServiceUnitOfWork.AnimalCategoryManager.
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
