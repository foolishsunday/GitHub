using System;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode_Task_1114
{
    public class Foo
    {
        Barrier barrier = new Barrier(1);
        public Foo()
        {
            var task1 = new Task(() =>
            {
                First(() =>
                {
                    Console.Write("first");
                    Thread.Sleep(1000);
                });
                barrier.RemoveParticipant();
            });
            var task2 = new Task(() =>
            {
                Task.WaitAll(task1);
                barrier.AddParticipant();
                Second(() =>
                {
                    Console.Write("second");
                    Thread.Sleep(500);
                });
                barrier.RemoveParticipant();
            });
            var task3 = new Task(() =>
            {
                Task.WaitAll(task1, task2);
                barrier.AddParticipant();
                Third(() =>
                {
                    Console.Write("third");
                });
                barrier.RemoveParticipant();
   
            });

            task1.Start();
            task2.Start();
            task3.Start();
        }

        public void First(Action printFirst)
        {

            // printFirst() outputs "first". Do not change or remove this line.
            printFirst();

        }

        public void Second(Action printSecond)
        {

            // printSecond() outputs "second". Do not change or remove this line.
            printSecond();
        }

        public void Third(Action printThird)
        {

            // printThird() outputs "third". Do not change or remove this line.
            printThird();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Foo foo = new Foo();
       
            Console.ReadKey();
        }
    }
}
