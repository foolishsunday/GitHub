using System;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode_Task_1116
{
    /*
class ZeroEvenOdd {
  public ZeroEvenOdd(int n) { ... }      // 构造函数
  public void zero(printNumber) { ... }  // 仅打印出 0
  public void even(printNumber) { ... }  // 仅打印出 偶数
  public void odd(printNumber) { ... }   // 仅打印出 奇数
}
相同的一个 ZeroEvenOdd 类实例将会传递给三个不同的线程：

线程 A 将调用 zero()，它只输出 0 。
线程 B 将调用 even()，它只输出偶数。
线程 C 将调用 odd()，它只输出奇数。
每个线程都有一个 printNumber 方法来输出一个整数。请修改给出的代码以输出整数序列 010203040506... ，其中序列的长度必须为 2n。

示例 1：

输入：n = 2
输出："0102"
说明：三条线程异步执行，其中一个调用 zero()，另一个线程调用 even()，最后一个线程调用odd()。正确的输出为 "0102"。
示例 2：

输入：n = 5
输出："0102030405"

         */
    class Program
    {
        static void Main(string[] args)
        {
            Action<int> act = (x) => Console.Write(x);
            ZeroEvenOdd zeo = new ZeroEvenOdd(5);
            Task.Run(() =>
            {
                zeo.Odd(act);
            });
            Task.Run(() =>
            {
                zeo.Zero(act);
            });
            Task.Run(() =>
            {
                zeo.Even(act);
            });
            Console.Read();
        }
    }
    public class ZeroEvenOdd
    {
        private int n;
        private SemaphoreSlim sZero = new SemaphoreSlim(1, 1);
        private SemaphoreSlim sOdd = new SemaphoreSlim(0, 1);
        private SemaphoreSlim sEven = new SemaphoreSlim(0, 1);
        //private Semaphore sZero = new Semaphore(1,1);
        //private Semaphore sOdd = new Semaphore(0, 1);
        //private Semaphore sEven = new Semaphore(0, 1);

        public ZeroEvenOdd(int n)
        {
            this.n = n; //0102030405
        }
         
    
        public void Zero(Action<int> printNumber)
        {
            for (int i = 0; i < n; i++)
            {
                sZero.Wait();
                //sZero.WaitOne();
                printNumber(0);
                if(i%2==0)
                    sOdd.Release();
                else
                    sEven.Release();

            }
        }

        public void Odd(Action<int> printNumber)
        {
            for (int i = 1; i <= n; i+=2)
            {
                sOdd.Wait();
                printNumber(i);
                sZero.Release();
            }
        }
        public void Even(Action<int> printNumber)
        {
            for (int i = 2; i <= n; i += 2)
            {
                sEven.Wait();
                printNumber(i);
                sZero.Release();
            }
        }


    }
}
