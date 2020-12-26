using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericT
{
    class Program
    {
        /// <summary>
        /// 本实例代码演示了如何利用泛型T，遍历任意类的所有属性
        /// </summary>
        /// <param name="args"></param>
        private static string Property2String<T>(T model)
        {
            //获取实例的type
            Type t = model.GetType();

            //把所有属性转化为list
            var list = t.GetProperties().ToList();
            string text = string.Empty;

            //遍历属性
            list.ForEach(x =>
            {
                object value = x.GetValue(model);

                //属性值和属性名转为字符串
                var str = string.Format(" [{0}={1}] ", x.Name, value.ToString());
                text += str;
            });
            return text;
        }
        static void Main(string[] args)
        {
            //使用方法

            //遍历Student类的所有属性
            var text = Property2String<Student>(new Student() { Name = "Levi", Id = "abcd", Age = 18 });
            Console.WriteLine(text);

            //遍历School类的所有属性
            text = Property2String<School>(new School() { Name = "college", Address = "beijing", ClassCount = 99 });
            Console.WriteLine(text);
            Console.Read();
        }
    }

    //纯属性的类
    public class Student
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
    }

    //纯属性的类
    public class School
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int ClassCount { get; set; }
    }
}
