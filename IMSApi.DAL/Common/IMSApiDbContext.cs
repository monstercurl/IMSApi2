using IMSApi.EntityModel.DTO.Accounts;
using IMSApi.EntityModel.Entities;
using IMSApi.EntityModel.Entities.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace IMSApi.DAL
{
    public class IMSApiDbContext : DbContext
    {
        public IMSApiDbContext(DbContextOptions<IMSApiDbContext> options):base(options)
        {
            
           

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().HasData(new Categories {Id=1, Category_Value = "Stiched",Parent_Category = 0 });
            modelBuilder.Entity<Categories>().HasData(new Categories {Id=2, Category_Value = "UnStiched", Parent_Category = 0 });
            modelBuilder.Entity<Categories>().HasData(new Categories {Id=3, Category_Value = "ReadyMade", Parent_Category = 0 });
            modelBuilder.Entity<ProductColor>().HasData(new ProductColor {ProductColor_ID=1, ProductColorValue = "Red"});
            modelBuilder.Entity<ProductColor>().HasData(new ProductColor { ProductColor_ID = 2, ProductColorValue = "Black" });
            modelBuilder.Entity<ProductColor>().HasData(new ProductColor { ProductColor_ID = 3, ProductColorValue = "Blue" });
            modelBuilder.Entity<ProductSize>().HasData(new ProductSize {Id = 4 ,Value = "23" });
            modelBuilder.Entity<ProductSize>().HasData(new ProductSize { Id=5, Value = "24" });
           
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, _role = UserRoles.admin });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, _role = UserRoles.endUser });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, _role = UserRoles.endUser_customer });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 4, _role = UserRoles.endUser_Reseller });
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<ProductColor> productColor { get; set; }
        public DbSet<ProductSize> productSize { get; set; }
        public DbSet<ProductDesign> productDesign { get; set; }
        public DbSet<Categories> Categories { get; set; }



        public DbSet<Vendor> Vendor { get; set; }


    }
}
