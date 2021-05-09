using BBSWeb.Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBSWeb.Repository
{
    public class BaseService<T> : IServiceInfo<T> where T : class
    {
        protected AppDbContext _context { get; private set; }
        public BaseService(AppDbContext context) 
        {
            _context = context;
        }
        public IQueryable<T> GetInfo()
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
