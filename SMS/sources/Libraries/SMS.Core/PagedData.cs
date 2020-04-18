using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Core
{
    public class PagedData<TEntity>
    {
        public IEnumerable<TEntity> Data { get; protected set; }
        public int TotalDataCount { get; protected set; }
        public int TotoalDispayableDataCount { get; protected set; }

        public PagedData(IEnumerable<TEntity> data, int totalDataCount, int totoalDispayableDataCount)
        {
            Data = data;
            TotalDataCount = totalDataCount;
            TotoalDispayableDataCount = totoalDispayableDataCount;
        }
    }
}
