using DbFirst.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirst.Service
{
    public class BaseService<T> : IService<T> where T : class
    {
        protected CimdbContext _context { get; private set; }
        public BaseService(CimdbContext context)
        {
            _context = context;
        }
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public virtual void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}
