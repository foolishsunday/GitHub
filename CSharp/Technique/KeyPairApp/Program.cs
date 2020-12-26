using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPairApp
{
    public class KeyPair
    { 
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class ProductKeyPairCollection : Collection<KeyPair>
    {
        public KeyPair this[string key]
        {
            get 
            {
                return this.Where(p => p.Key == key).ToList().FirstOrDefault();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ProductKeyPairCollection products = new ProductKeyPairCollection()
            {
                new KeyPair() { Key = "shenzhen", Value = "1200" },
                new KeyPair() { Key = "beijing", Value = "999" } 
            };
            Console.WriteLine(products["beijing"].Value);
            Console.Read();
        }
    }
}
