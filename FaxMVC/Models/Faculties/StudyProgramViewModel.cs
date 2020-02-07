﻿using Core.Faculties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaxMVC.Models.Faculties
{
    public class StudyProgramViewModel
    {
        public List<StudyProgram> StudyPrograms { get; set; }
        public int StudyProgramId { get; set; }
        public List<StudyProgram> UserStudyPrograms { get; set; }
        public int UserStudyProgramId { get; set; }
    }
}
