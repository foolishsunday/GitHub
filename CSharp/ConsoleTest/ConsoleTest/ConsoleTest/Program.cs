using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        public static class Line
        {
            public static string Tickets(int[] peopleInLine)
            {
                int income25 = 0, income50 = 0;
                for (int i=0;i<peopleInLine.Length;i++)
                {
                    var item = peopleInLine[i];

                    if (item == 25) income25++;
                    else if (item == 50)
                    {
                        if (income25 > 0)
                        {
                            income25--;
                            income50++;
                        }
                        else
                            return "NO";
                                                  
                    }
                    else//100
                    {
                        if (income50 > 0 && income25 > 0)
                        {
                            income50--;
                            income25--;

                        }
                        else
                        {
                            if (income25 < 3)
                                return "NO";
                            else
                                income25 -= 3;
                        }
                        //income[2]++;
                    }
                }
                return "YES";
            }
        }
        static void Main(string[] args)
        {

            Console.WriteLine(Line.Tickets(new int[] { 25, 100 }));
            Console.WriteLine(Line.Tickets(new int[] { 25, 50, 50 }));
            Console.WriteLine(Line.Tickets(new int[] { 25, 100 }));
            Console.WriteLine(Line.Tickets(new int[] { 25, 25, 50, 50, 100 }));
            Console.WriteLine("----------");
            Console.Read();
        }
    }

}
