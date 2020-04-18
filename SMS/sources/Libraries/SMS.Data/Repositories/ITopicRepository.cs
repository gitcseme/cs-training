using SMS.Core;
using SMS.Data.Entities;
using System;

namespace SMS.Data.Repositories
{
    public interface ITopicRepository : IRepositoryBase<Topic, Guid>
    {
    }
}