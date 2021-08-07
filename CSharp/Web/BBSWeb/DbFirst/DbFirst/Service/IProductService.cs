using DbFirst.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirst.Service
{
    public interface IProductService
    {
        //public Product FindProduct(int id);
        IEnumerable<Product> QueryAll();
    }
}
