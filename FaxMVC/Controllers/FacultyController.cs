using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application;
using Core;
using Core.Faculties;
using FaxMVC.Models.Faculties;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FaxMVC.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        public FacultyController(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            //Ovo ce definitivno radit sa new User()
            var user = await _userManager.FindByNameAsync("Smoki");

            List<StudyProgram> studyPrograms =
                _unitOfWork.UserStudyPrograms.GetAllStudyProgramsByUser(user).ToList();

            StudyProgramViewModel model = new StudyProgramViewModel
            {
                StudyPrograms = studyPrograms
            };

            return View(model);
        }
    }
}