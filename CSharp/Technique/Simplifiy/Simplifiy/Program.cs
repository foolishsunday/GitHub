using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplifiy
{
    public class Person
    {
        //1.全写
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //2.全简写
        public int Age { get; set; }

        //3.半简写
        private string address;
        public string Address => address;  //等价于 public int Age { get { return age; } }

        //4.只读，不可写入
        public float Money { get; }
        public float PrivateMoney { get; private set; }

        //5.get set有代码的简写
        //属性的用途之一：此处体现了属性的好处，用get给属性赋初值，set赋值可省去一个SetIntroduction()方法，使代码更简洁
        private string introduction;
        public string Introduction
        {
            get => string.Format($"{introduction}My name is {name}, I am {Age} years old");
            set => introduction = string.Format($"Hello {value}, ");
        }

        //等价于
        //public string Introduction
        //{
        //    get
        //    {
        //        return string.Format($"{introduction}My name is {name}, I am {Age} years old");
        //    }
        //    set 
        //    {
        //        introduction = string.Format($"Hello {value}, ");
        //    }

        //}

    }
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.Name = "Tom";
            person.Age = 18;
            //person.Address = "Shenzhen"; // 语法错误
            //person.Money = 100.0;// 语法错误
            //person.PrivateMoney = 1000.0// 语法错误

            Console.WriteLine(person.Introduction);//输出：My name is Tom, I am 18 years old
            
            person.Introduction = "Sofia";
            Console.WriteLine(person.Introduction);//输出：Hello Sofia, My name is Tom, I am 18 years old
            Console.ReadLine();
        }
    }
}
