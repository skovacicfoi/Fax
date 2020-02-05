using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Subjects
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public float MaxPoints { get; set; }
        public float AchievedPoints { get; set; }
        public PartOfSubject PartOfSubject { get; set; }
    }
}
