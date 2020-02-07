using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Subjects
{
    public class SubjectTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Semester { get; set; }
        public List<PartOfSubject> Parts { get; set; }
        public List<SubjectStudyProgram> StudyPrograms { get; set; }
    }
}
