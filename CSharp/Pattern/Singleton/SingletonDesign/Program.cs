using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesign
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    //单例模式与静态类比：单例模式可以有继承
    public sealed class Singleton//延迟加载
    {
        Singleton() { }
        public static Singleton Create
        {
            get => Nested.Instance;
        }
        class Nested
        {
            static Nested() { }
            internal static readonly Singleton Instance = new Singleton();
        }
    }
}
