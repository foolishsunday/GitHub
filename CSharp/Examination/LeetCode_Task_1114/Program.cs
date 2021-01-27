using System;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode_Task_1114
{
    public class Foo
    {
        Semaphore semaphore_second = new Semaphore(0, 1);
        Semaphore semaphore_third = new Semaphore(0, 1);
        public Foo()
        {
    
        }

        public void First(Action printFirst)
        {

            // printFirst() outputs "first". Do not change or remove this line.

            printFirst();
            semaphore_second.Release();

        }

        public void Second(Action printSecond)
        {

            // printSecond() outputs "second". Do not change or remove this line.
            semaphore_second.WaitOne();
            printSecond();
            semaphore_third.Release();
        }

        public void Third(Action printThird)
        {

            // printThird() outputs "third". Do not change or remove this line.
            semaphore_third.WaitOne();
            printThird();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Foo foo = new Foo();
            var task1 = new Thread(() =>
            {
                foo.First(() =>
                {
                    Console.Write("first");
                });
            });
            var task2 = new Thread(() =>
            {
                foo.Second(() =>
                {
                    Console.Write("second");
                });
            });
            var task3 = new Thread(() =>
            {
                foo.Third(() =>
                {
                    Console.Write("third");
                });

            });
            task3.Start();
            task2.Start();

            task1.Start();


            Console.ReadKey();
        }
    }
}
