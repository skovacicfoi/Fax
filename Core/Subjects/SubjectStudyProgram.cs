using Core.Faculties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Subjects
{
    public class SubjectStudyProgram
    {
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int StudyProgramId { get; set; }
        public StudyProgram StudyProgram { get; set; }
    }
}
