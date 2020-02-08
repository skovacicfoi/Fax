using Core.Subjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IPartTimesOfTeachingRepository :  IRepository<SubjectTimeOfTeaching>
    {
        IEnumerable<SubjectTimeOfTeaching> GetAllForSchedule(Schedule schedule);
    }
}
