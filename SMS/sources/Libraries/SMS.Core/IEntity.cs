using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Core
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
