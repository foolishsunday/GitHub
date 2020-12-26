using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.同时启动，等待结果完成后，统一输出结果
            //结果：两个线程同时启动，交替运行，等两者都完成后，输出最后的计算结果
            var mu = MultiplyNoAsync();
            var add = AddNoAsync();
            Console.WriteLine("计算乘法结果sum={0}, 计算加法结果sum={1}", mu.Result, add.Result);
            Console.WriteLine("---------End---------");
            Console.Read();

        }
        private async static Task<double> Multiply()
        {
            var task = Task.Run(() =>
            {
                double sum = 1, i = 1;
                long mi;

                Stopwatch sw = new Stopwatch();
                sw.Start();
         
                do
                {
                    sum *= i;
                    i++;
                    mi = sw.ElapsedMilliseconds;
                    Console.WriteLine("task id = {0}, i = {1}", Task.CurrentId, i);
                } while (mi < 200);

                sw.Stop();
                return sum;

            });
            return await task;
        }
        private async static Task<double> Add()
        {
            var task = Task.Run(() =>
            {
                double sum = 0, j = 1;
                long mi;

                Stopwatch sw = new Stopwatch();
                sw.Start();

                do
                {
                    sum += j;
                    j++;
                    mi = sw.ElapsedMilliseconds;
                    Console.WriteLine("task id = {0}, j = {1}", Task.CurrentId, j);
                } while (mi < 300);

                sw.Stop();
                return sum;

            });
            return await task;
        }

        private static Task<double> MultiplyNoAsync()
        {
            var task = Task.Run(() =>
            {
                double sum = 1, i = 1;
                long mi;

                Stopwatch sw = new Stopwatch();
                sw.Start();

                do
                {
                    sum *= i;
                    i++;
                    mi = sw.ElapsedMilliseconds;
                    Console.WriteLine("task id = {0}, mi = {1}", Task.CurrentId, i);
                } while (mi < 200);

                sw.Stop();
                return sum;

            });
            return task;
        }
        private async static Task<double> AddNoAsync()
        {
            var task = Task.Run(() =>
            {
                double sum = 0, j = 1;
                long mi;

                Stopwatch sw = new Stopwatch();
                sw.Start();

                do
                {
                    sum += j;
                    j++;
                    mi = sw.ElapsedMilliseconds;
                    Console.WriteLine("task id = {0}, mj = {1}", Task.CurrentId, j);
                } while (mi < 300);

                sw.Stop();
                return sum;

            });
            return await task;
        }
    }
}
