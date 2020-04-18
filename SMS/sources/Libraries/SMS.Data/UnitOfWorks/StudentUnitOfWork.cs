using SMS.Core;
using SMS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Data.UnitOfWorks
{
    public class StudentUnitOfWork : UnitOfWorkBase<SchoolContext>, IStudentUnitOfWork
    {

        public StudentUnitOfWork(string connectionStringName, string migrationAssemblyName) 
            : base(connectionStringName, migrationAssemblyName)
        {
            Students = new StudentRepository(_dbContext);
            Courses = new CourseRepository(_dbContext);
        }

        public IStudentRepository Students { get; protected set; }
        public ICourseRepository Courses { get; protected set; }
    }
}
