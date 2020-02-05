using Core.Subjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ISubjectsRepository : IRepository<Subject>
    {
        IEnumerable<Subject> GetAllWithPartsOfSubject();
    }
}
