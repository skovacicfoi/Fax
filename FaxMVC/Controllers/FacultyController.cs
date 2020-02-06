using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Core;
using Core.Faculties;
using FaxMVC.Models.Faculties;
using Microsoft.AspNetCore.Mvc;

namespace FaxMVC.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public FacultyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            //Ovo ce definitivno radit sa new User()
            List<StudyProgram> studyPrograms = await _unitOfWork.StudyPrograms.GetStudyProgramUsers(new User());
            StudyProgramViewModel model = new StudyProgramViewModel
            {
                StudyPrograms = studyPrograms
            };
            return View(model);
        }
    }
}