using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyWeb
{
    public interface IContainer
    {
        void Register<TFrom, TTo>() where TTo : TFrom;
        TFrom Resolve<TFrom>();
    }
}
