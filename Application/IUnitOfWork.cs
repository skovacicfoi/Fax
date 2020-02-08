using Application.Registries;
using Core;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Application
{
    public interface IUnitOfWork
    {
        UserManager<User> Users { get; }
        ISubjectsRepository Subjects { get; }
        IStudyProgramRepository StudyPrograms { get; }
        ISchedulesRepository Schedules { get; }
        IUserStudyProgramRepository UserStudyPrograms { get; }
        IPartTimesOfTeachingRepository TeachingTimes { get; }
        void Complete();
    }
}