using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Core;
using Core.Faculties;
using Core.Subjects;
using FaxMVC.Models.Schedules;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FaxMVC.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        public ScheduleController(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            var user = await _userManager.FindByNameAsync("Smoki");

            List<StudyProgram> userStudyPrograms =
                _unitOfWork.UserStudyPrograms.GetAllStudyProgramsByUser(user).ToList();


            CreateScheduleModel model = new CreateScheduleModel
            {
                StudyPrograms = userStudyPrograms
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateScheduleModel model)
        {
            var user = await _userManager.FindByNameAsync("Smoki");

            Schedule schedule = new Schedule
            {
                Semester = model.Semester,
                StudyProgramId = model.StudyProgramId,
                User = user
            };
            await _unitOfWork.Schedules.Add(schedule);
            _unitOfWork.Complete();
            return View("Index");
        }
    }
}