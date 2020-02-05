using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Faculties
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudyProgram> StudyPrograms { get; set; }
    }
}
