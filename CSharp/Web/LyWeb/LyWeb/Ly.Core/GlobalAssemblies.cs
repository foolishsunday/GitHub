using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ly.Core
{
    public static class GlobalAssemblies
    {
        /// <summary>
        /// 解决方案所有程序集
        /// </summary>
        public static readonly Assembly[] AllAssemblies = new Assembly[]
        {
            Assembly.Load("Ly.Core"),
            Assembly.Load("Ly.Entity"),
            Assembly.Load("Ly.IBusiness"),
            Assembly.Load("Ly.Business"),
            Assembly.Load("LyWeb"),
        };

        /// <summary>
        /// 解决方案所有自定义类
        /// </summary>
        public static readonly Type[] AllTypes = AllAssemblies.SelectMany(x => x.GetTypes()).ToArray();

        /// <summary>
        /// 超级管理员UserIId
        /// </summary>
        public const string ADMINID = "Admin";
    }
}
