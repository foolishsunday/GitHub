using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 3, 2, 4, 5, 6, 7, 7, 1, 1, 1, 1, 1, 1, 1 };
            int[] another = new int[] { 10, 11, 12 };
            var together = array.Union(another);//先求并集，会把重复元素合并为1个
            var orders = together.OrderBy(x => x);   //需引用：using System.Linq;
            foreach (var item in orders)
                Console.WriteLine(item);
            Console.Read();
        }
    }

}
