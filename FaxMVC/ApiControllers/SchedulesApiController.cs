using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FaxMVC.ApiControllers
{
    [Route("api/[controller]")]
    public class SchedulesApiController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public SchedulesApiController(IUnitOfWork unitOfWork)

        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var schedule = _unitOfWork.Schedules.GetWithSubjects(id);
            if(schedule == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(schedule);
            }
        }
        


        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
