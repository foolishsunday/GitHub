using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{

    class Program
    {

        static double Work(IDiscount discount, Func<IDiscount, double> proceed)
        {
            return proceed(discount);
        }
        static void Main(string[] args)
        {
            //Dictionary<string, string> map = new Dictionary<string, string>
            //{
            //    { "Name","Jack"},
            //    { "Address", "Shenzhen"}

            //};
            //Console.WriteLine(map["Name"]);
            //Console.WriteLine(map["Address"]);
            var sz = new SZDiscount();
            Func<IDiscount, double> pro = (x) =>
            {
                return x.Calc(3) + sz.Calc(4);
            };
            
            Console.WriteLine(Work(sz, pro));
            Console.WriteLine("----------");
            Console.Read();
        }
    }
    public interface IPrice { }
    public class ProductPrice : IPrice
    {
        public double Price { get; set; }
        public string Name { get; set; }
    }
    public interface IDiscount
    {
        double Calc(double srcPrice);
    }
    public class SZDiscount : IDiscount
    {
        public double Calc(double srcPrice)
        {
            return srcPrice * srcPrice;
        }
    }
    //public class AreaCalcDiscount<T> : IDiscount where T : new()
    //{
    //    Func<double, T> _func;
    //    public AreaCalcDiscount(Func<double, T> func)
    //    {
    //        _func = func;

    //    }

    //    public T Calc(double srcPrice)
    //    {
    //        return _func(srcPrice);
    //    }
    //}

}
