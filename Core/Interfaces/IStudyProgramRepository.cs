﻿using Core.Faculties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStudyProgramRepository : IRepository<StudyProgram>
    {
        Task<List<StudyProgram>> GetStudyProgramUsers(User user);
    }
}