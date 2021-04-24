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
            //1.0 Select：把符合条件的筛选出来
            Console.WriteLine("1.0.Select：把符合条件的筛选出来");
            string path = @"index.ppt";
            string[] names = ".word .xls .xlsx .ppt".Split(' ');
            IEnumerable<bool> targets = names.Select(p => path.EndsWith(p));//返回bool集合
            var isTarget = targets.Any(p => p == true);
            Console.WriteLine("Is target file? " + isTarget.ToString());

            //1.1 Select：把符合条件的筛选出来，返回结果时使用index参数
            Console.WriteLine("1.1.Select：把符合条件的筛选出来，带index参数");
            var addIndex = names.Select((item, index) =>
            {
                return index.ToString() + item; //0.word 1.xls...
            });
            foreach (var item in addIndex)
                Console.WriteLine(item);

            //1.2.0 Select：返回多个字段
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

            //1.2.1 Select：返回不同长度
            int nFloors = 10;
            string[] floors = Enumerable.Range(1, nFloors).Select(i => new string('*', i)).ToArray();
            foreach (var item in floors)
                Console.WriteLine(item);
            //1.3.1 SelectMany：List里面又有List，可以用它
            Console.WriteLine("---------1.3.1 SelectMany---------");
            string[] manyList = { "abc", "def", "lmn" };
            var selectMany = manyList.SelectMany(p => p.ToCharArray());    
            Console.WriteLine(string.Join("|", selectMany));//输出：a|b|c|d|e|f|l|m|n
            Console.WriteLine("---------1.3.1 SelectMany end---------");

            //1.3.2 SelectMany：
            //第一个参数：是一个函数，用来将第一个源序列中的每个元素映射到第二个源序列上
            //第二个参数：将根据两个序列中的每一对映射来投影出结果元素
            int[] oddList = { 1, 3, 5, 6 };
            int[] evenList = { 2, 4, 6, 8 };
            var values = oddList.SelectMany(es => evenList, (Odd, Even) => new { Odd, Even, Sum = Odd + Even });
            Console.WriteLine("---------SelectMany---------");
            foreach (var item in values)
                Console.WriteLine(string.Format("{0} {1} {2}", item.Odd, item.Even, item.Sum));


            Console.WriteLine("---------SelectMany End---------");
            var selectNew = from o in oddList
                            from e in evenList
                            //where o > e
                            select new { o, e, Sum = o + e };
            Console.WriteLine("---------selectNew---------");
            foreach (var item in selectNew)
                Console.WriteLine(string.Format("{0} {1} {2}", item.o, item.e, item.Sum));
            Console.WriteLine("---------selectNew End---------");

            //2 SingleOrDefault
            Console.WriteLine("SingleOrDefault:选取每个元素的单个字符");
            var text = "2or def6 ff3 gg1aa e4e pppspp5";
            var nums = text.Split(new char[0]);
            var numList = nums.Select(p => p.SingleOrDefault(c => char.IsDigit(c)));
            numList.ToList().ForEach(x => Console.WriteLine(x));

            //3.0 Agggregate:初始值是一个多个值的数组
            Console.WriteLine("Agggregate:第一个参数是初始值，第二个参数是要对每个元素调用的累加器函数");
            int threadcnt = 2;
            var queueTime = new int[] { 5, 3, 4 }.Aggregate(new int[threadcnt], (threads, val) =>
               {
                   threads[Array.IndexOf(threads, threads.Min())] += val; //先查出最小数的索引，再把该最小数
                   return threads;
               });
            Console.WriteLine(queueTime.Max());

            //3.1 Agggregate:初始值是一个单个值的数组
            Console.WriteLine("Agggregate:单个值的数组用法");
            var ag = names.Aggregate(new bool[1], (arr, agV) =>
            {
                arr[0] |= path.EndsWith(agV);
                return arr;
            });
            Console.WriteLine(ag[0]);

            //3.2 Agggregate:初始值是一个数
            Console.WriteLine("Agggregate:初始值是数的用法");
            var singleAgg = names.Aggregate(false, (preV, item) =>
            {
                return preV || path.EndsWith(item);
            });
            Console.WriteLine(singleAgg);

            //3.3 Aggregate:初始值是一个数2
            string[] signs = { "BMW", "Google", "Apple", "Mi" };
            var calcLen = signs.Aggregate(0, (len, s) =>
            {
                int sLen = s.Length;
                return Math.Max(len, sLen);
            });
            Console.WriteLine("Agggregate:初始值是一个数的用法, calcLen = {0}", calcLen);

            //4 GroupBy:数组中不重复的唯一
            Console.WriteLine("GroupBy:找出数组中不重复的唯一");
            var numberss = new List<int>() { 1, 1, 1, 2, 1, 1 };
            var unique = numberss.GroupBy(x => x).Single(x => x.Count() == 1).Key; 
            Console.WriteLine(unique);
            Console.Read();


        }
            

    }
}
