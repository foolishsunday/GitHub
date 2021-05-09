using DbFirst.Context;
using DbFirst.Entity;
using System;
using System.Linq;

namespace DbFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (CimdbContext db = new CimdbContext())
            {
                var query = db.Products.Where(x=>x.Id==4).FirstOrDefault();
                Product product = query as Product;
                Console.WriteLine($"Name={product.Name}");
                Console.ReadLine();
            }
     
            
        }
    }
}
