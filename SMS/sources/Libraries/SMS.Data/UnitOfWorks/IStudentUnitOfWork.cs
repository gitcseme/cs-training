using SMS.Core;
using SMS.Data.Repositories;

namespace SMS.Data.UnitOfWorks
{
    public interface IStudentUnitOfWork : IUnitOfWorkBase
    {
        IStudentRepository Students { get; }
        ICourseRepository Courses { get; }
    }
}