using SMS.Core;
using SMS.Data.Entities;
using System;

namespace SMS.Data.Repositories
{
    public class TopicRepository : RepositoryBase<Topic, Guid, SchoolContext>, ITopicRepository
    {
        public TopicRepository(SchoolContext context) : base(context)
        {
        }
    }
}
