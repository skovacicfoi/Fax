using Core;
using Core.Faculties;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Registries
{
    public class UserStudyProgramRepository : Repository<UserStudyProgram>, IUserStudyProgramRepository
    {
        public UserStudyProgramRepository(FaxDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<StudyProgram> GetAllStudyProgramsByUser(User user)
        {
            var userSP = _faxDbContext.UserStudyPrograms
                .Include(usp => usp.User)
                .Include(usp => usp.StudyProgram)
                .Where(usp => usp.User == user);

            foreach (var usp in userSP)
            {
                yield return usp.StudyProgram;
            }
        }
    }
}
