using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Subjects
{
    public class SubjectTimeOfTeaching
    {
        public int Id { get; set; }
        public PartOfSubject PartOfSubject { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
    }
}
