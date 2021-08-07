using EFCore.Sharding;
using Ly.Core;
using Ly.Entity;
using Ly.IBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.Business.Base
{
    public class Base_SchoolBusiness : BaseBusiness<Base_School>, IBase_SchoolBusiness, ITransientDependency
    {
        public Base_SchoolBusiness(IDbAccessor db) : base(db) { }

        public async Task<Base_School> GetSchool(int id)
        {
            return await GetEntityAsync(id);
        }
    }
}
