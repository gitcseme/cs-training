using SMS.Core;
using SMS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Data.UnitOfWorks
{
    public class TopicUnitOfWork : UnitOfWorkBase<SchoolContext>, ITopicUnitOfWork
    {
        public TopicUnitOfWork(string connectionStringName, string migrationAssemblyName) 
            : base(connectionStringName, migrationAssemblyName)
        {
            Topics = new TopicRepository(_dbContext);
            Courses = new CourseRepository(_dbContext);
        }

        public ITopicRepository Topics { get; protected set; }
        public ICourseRepository Courses { get; protected set; }
    }
}
