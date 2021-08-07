using EFCore.Sharding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.Business
{
    public abstract class BaseBusiness<T> where T:class, new()
    {
        public IDbAccessor Db { get; }
        public BaseBusiness(IDbAccessor db)
        {
            Db = db;
        }
        public T GetEntity(params object[] keyValue)
        {
            return Db.GetEntity<T>(keyValue);
        }
        public async Task<T> GetEntityAsync(params object[] keyValue)
        {
            return await Db.GetEntityAsync<T>(keyValue);
        }
    }
}
