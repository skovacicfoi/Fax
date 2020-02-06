using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Faculties
{
    public class UserStudyProgram
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int StudyProgramId { get; set; }
        public StudyProgram StudyProgram { get; set; }
    }
}
