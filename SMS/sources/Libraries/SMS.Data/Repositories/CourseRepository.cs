using SMS.Core;
using SMS.Data.Entities;
using System;

namespace SMS.Data.Repositories
{
    public class CourseRepository : RepositoryBase<Course, Guid, SchoolContext>, ICourseRepository
    {
        public CourseRepository(SchoolContext context) : base(context)
        {
        }
    }
}
