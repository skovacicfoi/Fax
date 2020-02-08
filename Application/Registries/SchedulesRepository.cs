using Core;
using Core.Interfaces;
using Core.Subjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Registries
{
    public class SchedulesRepository : Repository<Schedule>, ISchedulesRepository
    {
        public SchedulesRepository(FaxDbContext dbContext) :base(dbContext)
        {
        }

        public IEnumerable<Schedule> GetAllByUser(User user)
        {
            return _faxDbContext.Schedules.Include(s => s.User).Where(s => s.User == user).ToList();
        }

        public Schedule GetWithSubjects(int id)
        {
            return _faxDbContext.Schedules.Include(s => s.Subjects).FirstOrDefault(s => s.Id == id);
        }
    }
}
