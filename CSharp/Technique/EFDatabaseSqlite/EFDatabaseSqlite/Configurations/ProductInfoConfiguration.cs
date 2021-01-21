using EFDatabaseSqlite.Entity;
using System.Data.Entity.ModelConfiguration;


namespace EFDatabaseSqlite.Configurations
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
