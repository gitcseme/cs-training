using SMS.Core;
using SMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Data.Repositories
{
    public class StudentRepository : RepositoryBase<Student, Guid, SchoolContext>, IStudentRepository
    {
        public StudentRepository(SchoolContext context) : base(context)
        {
        }
    }
}
