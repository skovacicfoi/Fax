using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Core.Subjects;
using FaxMVC.Models.Schedules;
using Microsoft.AspNetCore.Identity;
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

        public async Task<IActionResult> Index()
        {

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            //treba promijeniti da traži logiranog usera
            var user = await _unitOfWork.Users.FindByNameAsync("sljunac");

            List<SubjectTimeOfTeaching> events = _unitOfWork.Subjects.GetAllSubjectsTimeOfTeachings().ToList();

            //dodat default property na schedule i odabrat onog koji je postavljen
            var schedule = _unitOfWork.Schedules.GetAllByUser(user).FirstOrDefault();

            //Treba promijenit da traži po logiranom useru ne hardkodanom
            GenerateEventsModel model = new GenerateEventsModel
            { Events = events,
                Json = JsonConvert.SerializeObject(events, jsonSerializerSettings),
                UserSchedules = _unitOfWork.Schedules.GetAllByUser(user),
                Schedule = schedule
            };

            var json = JsonConvert.SerializeObject(events, jsonSerializerSettings);
            

            return View(model);
        }

        public IActionResult Create(CreateScheduleModel model)
        {
            return View("Index");
        }
    }
}