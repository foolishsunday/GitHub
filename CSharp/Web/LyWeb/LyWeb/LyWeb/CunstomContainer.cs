using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyWeb
{
    public class CunstomContainer : IContainer
    {
        private Dictionary<string, Type> _map = new Dictionary<string, Type>();
        public void Register<TFrom, TTo>() where TTo: TFrom
        {
            this._map.Add(typeof(TFrom).FullName, typeof(TTo));
        }
        public TFrom Resolve<TFrom>()
        {
            return (TFrom)this.ResolveObject(typeof(TFrom));
        }
        public object ResolveObject(Type abstractType)
        {
            string key = abstractType.FullName;
            Type type = this._map[key];

            //构造函数
            var constructor = type.GetConstructors()[0];

            List<object> paraList = new List<object>();

            foreach (var item in constructor.GetParameters())
            {
                Type paraType = item.ParameterType; //参数类型
                object paraInstance = this.ResolveObject(paraType);
                paraList.Add(paraInstance);

            }

            object instance = Activator.CreateInstance(type, paraList.ToArray());

            return instance;
        }
    }
}
