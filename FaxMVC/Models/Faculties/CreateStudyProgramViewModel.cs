using Core.Faculties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaxMVC.Models.Faculties
{
    public class CreateStudyProgramViewModel
    {
        public List<StudyProgram> StudyPrograms { get; set; }
        public int StudyProgramId { get; set; }
    }
}
