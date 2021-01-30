using System;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode_Task_1195_FizzBuzz
{
    /*
编写一个可以从 1 到 n 输出代表这个数字的字符串的程序，但是：

如果这个数字可以被 3 整除，输出 "fizz"。
如果这个数字可以被 5 整除，输出 "buzz"。
如果这个数字可以同时被 3 和 5 整除，输出 "fizzbuzz"。
例如，当 n = 15，输出： 1, 2, fizz, 4, buzz, fizz, 7, 8, fizz, buzz, 11, fizz, 13, 14, fizzbuzz。

假设有这么一个类：

class FizzBuzz {
  public FizzBuzz(int n) { ... }               // constructor
  public void fizz(printFizz) { ... }          // only output "fizz"
  public void buzz(printBuzz) { ... }          // only output "buzz"
  public void fizzbuzz(printFizzBuzz) { ... }  // only output "fizzbuzz"
  public void number(printNumber) { ... }      // only output the numbers
}
请你实现一个有四个线程的多线程版  FizzBuzz， 同一个 FizzBuzz 实例会被如下四个线程使用：

线程A将调用 fizz() 来判断是否能被 3 整除，如果可以，则输出 fizz。
线程B将调用 buzz() 来判断是否能被 5 整除，如果可以，则输出 buzz。
线程C将调用 fizzbuzz() 来判断是否同时能被 3 和 5 整除，如果可以，则输出 fizzbuzz。
线程D将调用 number() 来实现输出既不能被 3 整除也不能被 5 整除的数字。


         */
    class Program
    {
        static void Main(string[] args)
        {
            Action fizz = () => Console.WriteLine("fizz");
            Action buzz = () => Console.WriteLine("buzz");
            Action fizzbuzz = () => Console.WriteLine("fizzbuzz");
            Action<int> num = (x) => Console.WriteLine(x);
            FizzBuzz fb = new FizzBuzz(15);
            Task.Run(() => fb.Fizz(fizz));
            Task.Run(() => fb.Buzz(buzz));
            Task.Run(() => fb.Fizzbuzz(fizzbuzz));
            Task.Run(() => fb.Number(num));
            Console.Read();
        }
    }
    public class FizzBuzz
    {
        private int n;
        Barrier barrier = new Barrier(4);
        public FizzBuzz(int n)
        {
            this.n = n;
        }

        // printFizz() outputs "fizz".
        public void Fizz(Action printFizz)//3
        {
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 != 0)
                    printFizz();
                barrier.SignalAndWait();
            }
        }

        // printBuzzz() outputs "buzz".
        public void Buzz(Action printBuzz)
        {
            for (int i = 1; i <= n; i++)
            {
                if (i % 5 == 0 && i % 3 != 0)
                    printBuzz();
                barrier.SignalAndWait();
            }
        }

        // printFizzBuzz() outputs "fizzbuzz".
        public void Fizzbuzz(Action printFizzBuzz)
        {
            for (int i = 1; i <= n; i++)
            {
                if (i % 5 == 0 && i % 3 == 0)
                    printFizzBuzz();
                barrier.SignalAndWait();
            }
        }

        // printNumber(x) outputs "x", where x is an integer.
        public void Number(Action<int> printNumber)
        {
            for (int i = 1; i <= n; i++)
            {
                if (i % 5 != 0 && i % 3 != 0)
                    printNumber(i);
                barrier.SignalAndWait();
            }
        }
    }
}
