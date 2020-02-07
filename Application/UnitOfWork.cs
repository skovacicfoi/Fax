using Application.Registries;
using Core;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FaxDbContext _faxDbContext;
        public ISubjectsRepository Subjects { get; private set; }
        public ISchedulesRepository Schedules { get; private set; }
        public UserManager<User> Users { get; private set; }
        public IStudyProgramRepository StudyPrograms { get; private set; }
        public IUserStudyProgramRepository UserStudyPrograms { get; private set; }
        public ISubjectTemplateRepository SubjectTemplates { get; private set; }

        public UnitOfWork(FaxDbContext faxDbContext, UserManager<User> userManager)
        {
            _faxDbContext = faxDbContext;
            Users = userManager;
            Subjects = new SubjectsRepository(faxDbContext);
            Schedules = new SchedulesRepository(faxDbContext);
            StudyPrograms = new StudyProgramRepository(faxDbContext);
            UserStudyPrograms = new UserStudyProgramRepository(faxDbContext);
            SubjectTemplates = new SubjectTemplateRepository(faxDbContext);
        }

        public void Complete()
        {
            _faxDbContext.SaveChanges();
        }

    }
}
