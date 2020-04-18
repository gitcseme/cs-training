using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Core
{
    public interface IUnitOfWorkBase : IDisposable
    {
        Task SaveAsync();
        void Save();
    }
}
