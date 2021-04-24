using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousTypes
{
    class Program
    {
        public static T Transform<T>(T element, Func<T, T> func)
        {
            return func(element);
        }
        static void Main(string[] args)
        {
            //匿名类型：1.编译器速度更快 2.避免错误 3.减少维护的代码
            var point = new { X = 123, Y = 444 };
            var result = Transform(point, p => new { X = p.X / 2, Y = p.Y + 1 });
            Console.WriteLine(point.X);
            Console.WriteLine(point.Y);
            Console.ReadLine();
        }
    }
}
