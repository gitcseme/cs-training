using SMS.Core;
using SMS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Data.UnitOfWorks
{
    public class CourseUnitOfWork : UnitOfWorkBase<SchoolContext>, ICourseUnitOfWork
    {
        public CourseUnitOfWork(string connectionStringName, string migrationAssemblyName) 
            : base(connectionStringName, migrationAssemblyName)
        {
            Courses = new CourseRepository(_dbContext);
            Topics = new TopicRepository(_dbContext);
        }

        public ICourseRepository Courses { get; protected set; }
        public ITopicRepository Topics { get; protected set; }
    }
}
