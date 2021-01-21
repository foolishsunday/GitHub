using EFDatabaseMysql.Entity;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDatabaseMysql.Configurations
{
    public class ProductInfoConfiguration : EntityTypeConfiguration<ProductInfo>
    {
        public ProductInfoConfiguration()
        {
            this.HasKey(p => p.Id);
            this.Property(p => p.Name).HasMaxLength(100);
        }
    }
}
