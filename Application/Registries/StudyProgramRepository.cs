using Core;
using Core.Faculties;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Registries
{
    public class StudyProgramRepository : Repository<StudyProgram>, IStudyProgramRepository
    {
        public StudyProgramRepository(FaxDbContext dbContext) : base(dbContext)
        {
        }

    }
}
