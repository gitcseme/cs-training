using SMS.Core;
using SMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Data.Repositories
{
    public interface IStudentRepository : IRepositoryBase<Student, Guid>
    {
    }
}
