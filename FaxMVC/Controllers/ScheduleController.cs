using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using FaxMVC.Models.Schedules;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

        public IActionResult Create(CreateScheduleModel model)
        {
            return View("Index");
        }
    }
}