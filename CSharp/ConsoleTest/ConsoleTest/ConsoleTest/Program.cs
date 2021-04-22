using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{

    class Program
    {
        
        static void Main(string[] args)
        {
            Dictionary<string, string> map = new Dictionary<string, string>
            {
                { "Name","Jack"},
                { "Address", "Shenzhen"}

            };
            Console.WriteLine(map["Name"]);
            Console.WriteLine(map["Address"]);
            
            Console.WriteLine("----------");
            Console.Read();
        }
    }

}
