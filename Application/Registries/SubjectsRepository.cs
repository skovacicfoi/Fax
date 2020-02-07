using Core;
using Core.Interfaces;
using Core.Subjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Registries
{
    public class SubjectsRepository : Repository<Subject>, ISubjectsRepository
    {
        public SubjectsRepository(FaxDbContext dbContext) : base(dbContext)
        {
        }
        public IEnumerable<Subject> GetAllWithPartsOfSubject()
        {
            return _faxDbContext.Subjects
                .Include(s => s.Parts)
                    .ThenInclude(p => p.TimesOfTeaching)
                .Include(s => s.Parts)
                    .ThenInclude(p => p.Exams);
        }

        public IEnumerable<SubjectTimeOfTeaching> GetAllSubjectsTimeOfTeachings()
        {
            var subjects =  _faxDbContext.Subjects.Include(s => s.Parts).ThenInclude(tt => tt.TimesOfTeaching);
            foreach (var subject in subjects)
            {
                foreach (var part in subject.Parts)
                {
                    foreach (var timeOfTeaching in part.TimesOfTeaching)
                    {
                        yield return timeOfTeaching;
                    }
                }
            }
        }
    }
}
