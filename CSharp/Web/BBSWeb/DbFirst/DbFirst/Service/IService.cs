using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirst.Service
{
    public interface IService<T> : IDisposable
    {
        IQueryable<T> GetAll();
    }

}
