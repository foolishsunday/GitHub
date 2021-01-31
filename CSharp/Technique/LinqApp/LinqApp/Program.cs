using CommonTest;
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
            //1.0.Select：把符合条件的筛选出来
            Console.WriteLine("1.0.Select：把符合条件的筛选出来");
            string path = @"index.ppt";
            string[] names = ".word .xls .xlsx .ppt".Split(' ');
            IEnumerable<bool> targets = names.Select(p => path.EndsWith(p));//返回bool集合
            var isTarget = targets.Any(p => p == true);
            Console.WriteLine("Is target file? " + isTarget.ToString());

            //1.1.Select：把符合条件的筛选出来，返回结果时使用index参数
            Console.WriteLine("1.1.Select：把符合条件的筛选出来，带index参数");
            var addIndex = names.Select((item, index) =>
            {
                return index.ToString() + item; //0.word 1.xls...
            });
            foreach (var item in addIndex)
                Console.WriteLine(item);

            //1.2.Select：返回多个字段
            Console.WriteLine("1.2.Select：返回多个字段");
            List<Person> persons = new List<Person>()
            {
                new Person(){ Name="Levi", Address="广东"},
                new Person(){ Name="Jack",Address="杭州"}
            };
            var newPersons = persons.Select(x =>
            {
                return new
                {
                    HeadChar = x.Name.Substring(0, 1),  //名字首字母
                    Detail = "Name = " + x.Name + ";" + " Address = " + x.Address   //详细信息：名字+地址
                };
            });
            foreach (var item in newPersons)
                Console.WriteLine(item.HeadChar + "-" + item.Detail);
            Console.WriteLine("------------------");

            //2.SingleOrDefault
            Console.WriteLine("SingleOrDefault:选取每个元素的单个字符");
            var text = "2or def6 ff3 gg1aa e4e pppspp5";
            var nums = text.Split(new char[0]);
            var numList = nums.Select(p => p.SingleOrDefault(c => char.IsDigit(c)));
            numList.ToList().ForEach(x => Console.WriteLine(x));

            //3.0.Agggregate:初始值是一个多个值的数组
            Console.WriteLine("Agggregate:第一个参数是初始值，第二个参数是要对每个元素调用的累加器函数");
            int threadcnt = 2;
            var queueTime = new int[] { 5, 3, 4 }.Aggregate(new int[threadcnt], (threads, val) =>
               {
                   threads[Array.IndexOf(threads, threads.Min())] += val; //先查出最小数的索引，再把该最小数
                   return threads;
               });
            Console.WriteLine(queueTime.Max());

            //3.1.Agggregate:初始值是一个单个值的数组
            Console.WriteLine("Agggregate:单个值的数组用法");
            var ag = names.Aggregate(new bool[1], (arr, agV) =>
            {
                arr[0] |= path.EndsWith(agV);
                return arr;
            });
            Console.WriteLine(ag[0]);

            //3.2.Agggregate:初始值是一个数
            Console.WriteLine("Agggregate:初始值是数的用法");
            var singleAgg = names.Aggregate(false, (preV, item) =>
            {
                return preV || path.EndsWith(item);
            });
            Console.WriteLine(singleAgg);

            //4.GroupBy:数组中不重复的唯一
            Console.WriteLine("GroupBy:找出数组中不重复的唯一");
            var numberss = new List<int>() { 1, 1, 1, 2, 1, 1 };
            var unique = numberss.GroupBy(x => x).Single(x => x.Count() == 1).Key; 
            Console.WriteLine(unique);
            Console.Read();

            //5.Dictionary赋初值方式
            var newDict = new Dictionary<string, List<int>>()
            {
                ["pos"] = new List<int>(),
                ["peaks"] = new List<int>()
            };
            var nDict = new Dictionary<string, int[]>()
            {
                {"peaks", new int[]{123 } },
                {"pos", new int[]{456 }}
            };
        }
            

    }
}
