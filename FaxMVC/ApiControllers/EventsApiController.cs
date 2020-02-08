using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Core.Subjects;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FaxMVC.ApiControllers
{
    [Route("api/[controller]")]
    public class EventsApiController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public EventsApiController(IUnitOfWork unitOfWork)

        {
            _unitOfWork = unitOfWork;
        }


        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{scheduleId}")]
        public async Task<IActionResult> Get(int scheduleId)
        {
            var s = new Schedule { Id = scheduleId };
            var teachingTimes = _unitOfWork.TeachingTimes.GetAllForSchedule(s);

            if (teachingTimes == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(teachingTimes);
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
