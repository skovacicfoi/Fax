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
        private readonly IUnitOfWork _unitOfWork;
        public StudyProgramRepository(FaxDbContext dbContext, IUnitOfWork unitOfWork) : base(dbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<StudyProgram>> GetStudyProgramUsers(User user)
        {
            UserStudyProgram userStudyProgram = await _unitOfWork.UserStudyPrograms.Find(usp => usp.User == user);
            List<StudyProgram> studyPrograms = new List<StudyProgram>();

            //foreach(var i in userStudyProgram)
            //{
            studyPrograms.Add(userStudyProgram.StudyProgram);
            //}

            return studyPrograms;
        }
    }
}
