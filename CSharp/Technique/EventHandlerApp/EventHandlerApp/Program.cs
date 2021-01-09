using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerApp
{
    public class Headmaster
    {
        public event EventHandler<string> ActHandler;
        public void Come()
        {
            Console.WriteLine("校长来了");

            ActHandler(null, "王校长");
        }
    }
    public class Students
    {
        public void Action_Master(object sender, string name)
        {
            Console.WriteLine("全班起立，喊：{0}好", name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Students student = new Students();
            Headmaster master = new Headmaster();

            master.ActHandler += student.Action_Master;

            Console.WriteLine("-----------------------");
            master.Come();
            Console.Read();
        }
    }


}
