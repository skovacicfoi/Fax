using Core;
using Core.Faculties;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Registries
{
    public class UserStudyProgramRepository : Repository<UserStudyProgram>, IUserStudyProgramRepository
    {
        public UserStudyProgramRepository(FaxDbContext dbContext) : base(dbContext)
        {

        }
    }
}
