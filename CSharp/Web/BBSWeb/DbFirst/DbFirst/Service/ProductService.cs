using DbFirst.Context;
using DbFirst.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirst.Service
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(CimdbContext context) : base(context)
        {
        }
        public IEnumerable<Product> QueryAll()
        {
            return this.GetAll();
        }
    }
}
