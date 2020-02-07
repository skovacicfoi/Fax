using Core.Faculties;
using Core.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaxMVC.Models.Subjects
{
    public class CreateSubjectTemplateModel
    {
        public string Name { get; set; }
        public int Semester { get; set; }
        public List<string> partOfSubjectNames { get; set; }
        public List<SubjectStudyProgram> SubjecdStudyPrograms { get; set; }
        public List<StudyProgram> StudyPrograms { get; set; }
        public int StudyProgramId { get; set; }
    }
}
