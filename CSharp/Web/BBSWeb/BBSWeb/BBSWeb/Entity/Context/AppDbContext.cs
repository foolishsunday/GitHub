using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBSWeb.Entity.Context
{
    public class AppDbContext : DbContext
    {
        //public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseMySql("server=127.0.0.1;user id=root;database=burnintest;password=itc123!@#", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.16-mysql"));
        //    }
        //}
        //protected override void OnModelCreating(ModelBuilder builder) 
        //{
        //    builder.HasCharSet("utf8mb4").UseCollation("utf8mb4_0900_ai_ci");
        //    builder.Entity<Student>(entity =>
        //    {
        //        entity.ToTable("Student");

        //        entity.Property(e => e.Id)
        //            .HasColumnType("int(11)")
        //            .ValueGeneratedNever()
        //            .HasColumnName("id");

        //        entity.Property(e => e.Name)
        //            .HasMaxLength(45)
        //            .HasColumnName("name");
        //        entity.Property(e => e.Major)
        //            .HasMaxLength(45)
        //            .HasColumnName("Major");
        //        entity.Property(e => e.Email)
        //            .HasMaxLength(45)
        //            .HasColumnName("Email");
        //    });
        //    //OnModelCreatingPartial(builder);
        //}
        //private void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
