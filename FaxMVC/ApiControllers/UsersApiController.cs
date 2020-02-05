using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace FaxMVC.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersApiController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsersApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET api/<controller>/5
        [HttpGet("{username}")]
        public async Task<IActionResult> Get(string username)
        {
            var user = await _unitOfWork.Users.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }

        }
    }
}
