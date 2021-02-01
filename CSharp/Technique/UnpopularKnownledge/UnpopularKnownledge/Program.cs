using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnpopularKnownledge
{
    [TestFixture]
    class Program
    {
        [Test]
        static void Main(string[] args)
        {
            
            //1.比较2个序列是否相同
            List<string> a = new List<string>() { "123", "456", "789", "abcd" };
            List<string> b = new List<string>() { "123", "456", "789", "abcd" };
            bool isEqual = a.SequenceEqual(b);  //true
            Assert.IsTrue(isEqual);

            //2.Enumerable产生重复的序列
            var repeats = new List<int>(Enumerable.Repeat(0, 5));
            Assert.AreEqual(repeats, new int[] { 0, 0, 0, 0, 0 });//true

            //3.Enumerable生成某区间序列 0,1,2...
            var sequence = new List<int>(Enumerable.Range(1, 3));
            Assert.AreEqual(sequence, new int[] { 1, 2, 3 });//true

            //4.生成重复字符
            var repstr = new string('*', 4);
            Assert.AreEqual(repstr, "****");//true

            //5.Dictionary赋初值方式
            var newDict = new Dictionary<string, List<int>>()
            {
                ["pos"] = new List<int>(),
                ["peaks"] = new List<int>()
            };
            var nDict = new Dictionary<string, int[]>()
            {
                {"peaks", new int[]{ 123 }},
                {"pos", new int[]{ 456 }}
            };

            //6.ConcurrentDictionary 线程安全
            var cd = new ConcurrentDictionary<string, int[]>();
            cd.AddOrUpdate("peaks", new int[2] { 123,456},(k,v)=>
            {
                var cv1 = v[0];
                var cv2 = v[1];
                return v;   //Add的时候不进这里，只有update时才进
            });
            cd.AddOrUpdate("peaks", new int[2] { 123, 456 }, (k, v) => new int[1] { 111});
            var cdv = cd["peaks"];
         
            Console.WriteLine("Yes.");
            Console.Read();

           
        }
    }

}
