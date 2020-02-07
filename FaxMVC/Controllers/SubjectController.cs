using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Core.Faculties;
using Core.Subjects;
using FaxMVC.Models.Subjects;
using Microsoft.AspNetCore.Mvc;

namespace FaxMVC.Controllers
{
    public class SubjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var subjects = await _unitOfWork.SubjectTemplates.GetAll();
            SubjectTemplateViewModel model = new SubjectTemplateViewModel {
                SubjectTemplates = subjects.ToList(),
            };
            return View(model);
        }

        public async Task<IActionResult> CreateAsync()
        {
            var studyPrograms = await _unitOfWork.StudyPrograms.GetAll();
            var parts = Enum.GetValues(typeof(PartOfSubjectName));
            List<string> strParts = new List<string>();
            foreach(var p in parts)
            {
                strParts.Add(p.ToString());
            }
            CreateSubjectTemplateModel model = new CreateSubjectTemplateModel
            {
                StudyPrograms = studyPrograms.ToList(),
                partOfSubjectNames = strParts
            };
            return View(model);
        }
    }
}