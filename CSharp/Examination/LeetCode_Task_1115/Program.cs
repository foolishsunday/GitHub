using System;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode_Task_1115
{
    /*
     两个不同的线程将会共用一个 FooBar 实例。其中一个线程将会调用 foo() 方法，另一个线程将会调用 bar() 方法。

    请设计修改程序，以确保 "foobar" 被输出 n 次。

         */
    class FooBar
    {
        private int n;

        public AutoResetEvent fooSignal = new AutoResetEvent(false);
        public AutoResetEvent barSignal = new AutoResetEvent(false);
        public FooBar(int n)
        {
            this.n = n;
            fooSignal.Set();


        }
        public void Foo(Action printFoo)
        {

            for (int i = 0; i < n; i++)
            {
                fooSignal.WaitOne();
                printFoo();
                barSignal.Set();
            }

        }

        public void Bar(Action printBar)
        {
            for (int i = 0; i < n; i++)
            {
                barSignal.WaitOne();
                printBar();
                fooSignal.Set();

            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var fb = new FooBar(1000);

            var ts1 = new Thread(() => fb.Foo(()=>Console.Write("foo")));
            var ts2 = new Thread(() => fb.Bar(() => Console.Write("bar")));
            ts1.Start();
            ts2.Start();
            Console.Read();
        }
    }
}
