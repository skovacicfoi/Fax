using Core.Subjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaxMVC.Models.Schedules
{
    public class GenerateEventsModel
    {
        public List<SubjectTimeOfTeaching> Events = new List<SubjectTimeOfTeaching>();
        public string Json { get; set; }
    }
}
