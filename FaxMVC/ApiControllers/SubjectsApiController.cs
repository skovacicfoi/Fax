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
    public class SubjectsApiController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public SubjectsApiController(IUnitOfWork unitOfWork)

        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var subjects = await _unitOfWork.Subjects.GetAll();

            return Ok(subjects);
        }

        [HttpGet("schedule/{scheduleId}")]
        public IActionResult GetBySchedule(int scheduleId)
        {
            var subjects = _unitOfWork.Subjects.GetAllBySchedule(scheduleId);

            return Ok(subjects);
        }

        [HttpGet("parts/{subjectId}")]
        public IActionResult GetParts(int subjectId)
        {
            var parts = _unitOfWork.Subjects.GetAllParts(subjectId);

            return Ok(parts);
        }
    }
}
