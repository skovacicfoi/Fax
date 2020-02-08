using Core.Subjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ISchedulesRepository : IRepository<Schedule>
    {
        IEnumerable<Schedule> GetAllByUser(User user);
        Schedule GetWithSubjects(int id);
    }
}
