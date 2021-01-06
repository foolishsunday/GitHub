using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList<int, string> list = new SortedList<int, string>();
            list.Add(3, "c");
            list.Add(1, "a");
            list.Add(2, "b");
            list.Add(88, "f");
            list.Add(34, "e");
            list.Add(22, "d");
            list.Reverse().ToList().ForEach(x => Console.WriteLine(x));
            Console.Read();
        }
    }
}
