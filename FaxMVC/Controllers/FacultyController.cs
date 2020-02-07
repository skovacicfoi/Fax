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

            List<StudyProgram> userStudyPrograms = 
                _unitOfWork.UserStudyPrograms.GetAllStudyProgramsByUser(user).ToList();
            
            var sp = await _unitOfWork.StudyPrograms.GetAll();
            List<StudyProgram> studyPrograms = sp.ToList();

            StudyProgramViewModel model = new StudyProgramViewModel
            {
                UserStudyPrograms = userStudyPrograms,
                StudyPrograms = studyPrograms
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(StudyProgramViewModel model)
        {
            var user = await _userManager.FindByNameAsync("Smoki");
            var sp = await _unitOfWork.StudyPrograms.GetById(model.StudyProgramId);
            UserStudyProgram usp = new UserStudyProgram
            {
                UserId = user.Id,
                StudyProgramId = model.StudyProgramId,
            };
            await _unitOfWork.UserStudyPrograms.Add(usp);
            _unitOfWork.Complete();
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(StudyProgramViewModel model)
        {
            var user = await _userManager.FindByNameAsync("Smoki");
            var sp = await _unitOfWork.StudyPrograms.GetById(model.StudyProgramId);
            UserStudyProgram usp = new UserStudyProgram
            {
                UserId = user.Id,
                StudyProgramId = model.StudyProgramId,
            };
            await _unitOfWork.UserStudyPrograms.Delete(usp);
            _unitOfWork.Complete();
            return View("Index");
        }
    }
}