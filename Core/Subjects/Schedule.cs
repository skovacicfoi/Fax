using Core.Faculties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Subjects
{
    public class Schedule
    {
        public int Id { get; set; }
        public int Semester { get; set; }
        public User User { get; set; }
        public List<Subject> Subjects { get; set; }
        public StudyProgram StudyProgram { get; set; }
        public int StudyProgramId { get; set; }
    }
}
