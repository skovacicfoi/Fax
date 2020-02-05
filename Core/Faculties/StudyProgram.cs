using Core.Subjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Faculties
{
    public class StudyProgram
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Faculty Faculty { get; set; }
        public List<Schedule> StudentSchedules { get; set; }
        public List<SubjectStudyProgram> Subjects { get; set; }

    }
}
