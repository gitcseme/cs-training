using SMS.Core;
using SMS.Data.Repositories;

namespace SMS.Data.UnitOfWorks
{
    public interface ICourseUnitOfWork : IUnitOfWorkBase
    {
        ICourseRepository Courses { get; }
        ITopicRepository Topics { get; }
    }
}