using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Core.Subjects;
using FaxMVC.Models.Schedules;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FaxMVC.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ScheduleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            List<SubjectTimeOfTeaching> events = _unitOfWork.Subjects.GetAllSubjectsTimeOfTeachings().ToList();
            GenerateEventsModel model = new GenerateEventsModel { Events = events, Json = JsonConvert.SerializeObject(events, jsonSerializerSettings) };

            var json = JsonConvert.SerializeObject(events, jsonSerializerSettings);
            

            return View(model);
        }

        public IActionResult Create(CreateScheduleModel model)
        {
            return View("Index");
        }
    }
}