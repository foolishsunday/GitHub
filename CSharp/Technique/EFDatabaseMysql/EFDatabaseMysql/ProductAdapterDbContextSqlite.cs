//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EFDatabaseMysql
//{
//    public class ProductAdapterDbContextSqlite : DbContext
//    {

//        //在Form1.cs中使用了静态类Database(var db = DataBase.GetDbContext())，实际等于使用了这个构造函数：public ProductAdapterDbContextSqlite("MiniDb")
//        public ProductAdapterDbContextSqlite(string nameOrConnectionString) : base(nameOrConnectionString)
//        {

//        }
//        public DbSet<ProductInfo> ProductInfo { get; set; }
//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
//            modelBuilder.Configurations.Add(new ProductInfoConfiguration());

//            var init = new DatabaseInitializer();

//            System.Data.Entity.Database.SetInitializer(init);
//        }
//    }
//    class DatabaseInitializer : CreateDatabaseIfNotExists<ProductAdapterDbContextSqlite>
//    {
//        public DatabaseInitializer() : base()
//        {
//        }
//        protected override void Seed(ProductAdapterDbContextSqlite context)
//        {
//            base.Seed(context);
//        }
//    }
//    public static class DataBase
//    {
//        public const string DbConfigName = "MiniDb";
//        public static ProductAdapterDbContextSqlite GetDbContext()
//        {
//            return new ProductAdapterDbContextSqlite(DbConfigName);
//        }
//    }
//}
