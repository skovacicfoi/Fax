using Core.Faculties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Subjects
{
    public class SubjectStudyProgram
    {
        public int SubjectTemplateId { get; set; }
        public SubjectTemplate SubjectTemplate { get; set; }
        public int StudyProgramId { get; set; }
        public StudyProgram StudyProgram { get; set; }
    }
}
