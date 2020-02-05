using Core;
using Core.Interfaces;
using Core.Subjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Registries
{
    public class SchedulesRepository : Repository<Schedule>, ISchedulesRepository
    {
        public SchedulesRepository(FaxDbContext dbContext) :base(dbContext)
        {
        }
    }
}
