using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBSWeb.Repository
{
    public interface IServiceInfo<T> : IDisposable
    {
        IQueryable<T> GetInfo();

    }
}
