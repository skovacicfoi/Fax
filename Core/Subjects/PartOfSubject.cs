using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Subjects
{
    public class PartOfSubject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinimumAttendance { get; set; }
        public int CurrentAttendance { get; set; }
        public List<SubjectTimeOfTeaching> TimesOfTeaching { get; set; }
        public Subject Subject { get; set; }
        public List<Exam> Exams { get; set; }
    }
}
