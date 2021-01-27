using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqApp
{
    class Program
    {      
        static void Main(string[] args)
        {
            //1.Select
            Console.WriteLine("Select的应用:创建一个新的结果字段");
            string path = @"index.ppt";
            string[] names = ".word .xls .xlsx .ppt".Split(' ');
            var targets = names.Select(p => path.EndsWith(p));
            var isTarget = targets.Any(p => p == true);
            Console.WriteLine("Is target file? " + isTarget.ToString());


            //2.SingleOrDefault
            Console.WriteLine("SingleOrDefault:选取每个元素的单个字符");
            var text = "2or def6 ff3 gg1aa e4e pppspp5";
            var nums = text.Split(new char[0]);
            var numList = nums.Select(p => p.SingleOrDefault(c => char.IsDigit(c)));
            numList.ToList().ForEach(x => Console.WriteLine(x));

            //3.Agggregate:初始值是一个多个值的数组
            Console.WriteLine("Agggregate:第一个参数是初始值，第二个参数是要对每个元素调用的累加器函数");
            int threadcnt = 2;
            var queueTime = new int[] { 5, 3, 4 }.Aggregate(new int[threadcnt], (threads, val) =>
               {
                   threads[Array.IndexOf(threads, threads.Min())] += val; //先查出最小数的索引，再把该最小数
                   return threads;
               });
            Console.WriteLine(queueTime.Max());

            //Agggregate:初始值是一个单个值的数组
            Console.WriteLine("Agggregate:单个值的数组用法");
            var ag = names.Aggregate(new bool[1], (arr, agV) =>
            {
                arr[0] |= path.EndsWith(agV);
                return arr;
            });
            Console.WriteLine(ag[0]);

            //Agggregate:初始值是一个数
            Console.WriteLine("Agggregate:初始值是数的用法");
            var singleAgg = names.Aggregate(false, (preV, item) =>
            {
                return preV || path.EndsWith(item);
            });
            Console.WriteLine(singleAgg);

            //4.GroupBy:数组中不重复的唯一
            Console.WriteLine("GroupBy:找出数组中不重复的唯一");
            Console.WriteLine(GetUnique(new List<int>() { 1, 1, 1, 2, 1, 1 }));
            Console.Read();
        }
        static int GetUnique(IEnumerable<int> numbers) =>
            numbers.GroupBy(x => x).Single(x => x.Count()==1).Key;

    }
}
