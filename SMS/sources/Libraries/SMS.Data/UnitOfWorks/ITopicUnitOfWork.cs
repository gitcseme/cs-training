using SMS.Core;
using SMS.Data.Repositories;

namespace SMS.Data.UnitOfWorks
{
    public interface ITopicUnitOfWork : IUnitOfWorkBase
    {
        ITopicRepository Topics { get; }
        ICourseRepository Courses { get; }
    }
}