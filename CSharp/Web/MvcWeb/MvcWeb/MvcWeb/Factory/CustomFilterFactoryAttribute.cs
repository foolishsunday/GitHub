using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWeb.Factory
{
    public class CustomFilterFactoryAttribute : Attribute, IFilterFactory
    {
        private Type filterType = null;
        public CustomFilterFactoryAttribute(Type type)
        {
            this.filterType = type;
        }
        public bool IsReusable => true;

        //IFilterMetadata空接口，为了标识是一个Filter
        public IFilterMetadata CreateInstance(IServiceProvider provider)
        {
            return (IFilterMetadata)provider.GetService(this.filterType);
        }
    }
}
