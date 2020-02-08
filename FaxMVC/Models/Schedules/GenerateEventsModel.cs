using Core;
using Core.Subjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FaxMVC.Models.Schedules
{
    public class GenerateEventsModel
    {
        public List<SubjectTimeOfTeaching> Events = new List<SubjectTimeOfTeaching>();
        public Schedule Schedule { get; set; }
        public SubjectTimeOfTeaching NewEvent { get; set; }
        public IEnumerable<Schedule> UserSchedules { get; set; }
        public string Json { get; set; }
    }
}
