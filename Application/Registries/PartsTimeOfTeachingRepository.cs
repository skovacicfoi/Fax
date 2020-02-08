using Core;
using Core.Interfaces;
using Core.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Registries
{
    public class PartsTimeOfTeachingRepository : Repository<SubjectTimeOfTeaching>, IPartTimesOfTeachingRepository
    {
        public PartsTimeOfTeachingRepository(FaxDbContext dbContext) : base(dbContext)
        {
        }


        public IEnumerable<SubjectTimeOfTeaching> GetAllForSchedule(Schedule schedule)
        {
            return _faxDbContext.SubjectTimeOfTeachings.Where(spt => spt.PartOfSubject.Subject.Schedule.Id == schedule.Id);
        }
    }
}
