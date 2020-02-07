using Core;
using Core.Interfaces;
using Core.Subjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Registries
{
    public class SubjectTemplateRepository : Repository<SubjectTemplate>, ISubjectTemplateRepository
    {
        public SubjectTemplateRepository(FaxDbContext dbContext) : base(dbContext)
        {
        }
    }
}
