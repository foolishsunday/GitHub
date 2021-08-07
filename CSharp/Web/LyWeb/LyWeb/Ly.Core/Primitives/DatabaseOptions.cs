using EFCore.Sharding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.Core.Primitives
{
    public class DatabaseOptions
    {
        public string ConnectionString { get; set; }
        public DatabaseType DatabaseType { get; set; }
    }
}
