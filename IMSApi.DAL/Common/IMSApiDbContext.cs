using IMSApi.EntityModel.DTO.Accounts;
using IMSApi.EntityModel.Entities;
using IMSApi.EntityModel.Entities.CartAndWishList;
using IMSApi.EntityModel.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
            modelBuilder.Entity<Product>()
            .HasMany(b => b.productDesign)
            .WithOne().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
           .HasMany(b => b.product_images)
           .WithOne().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductDesign>()
           .HasMany(b => b.product_design_images)
           .WithOne().OnDelete(DeleteBehavior.Cascade);

         //   modelBuilder.Entity<Product>()
         //.HasMany(b => b.Image_Urls)
         //.WithOne().OnDelete(DeleteBehavior.Cascade);

            

            modelBuilder.Entity<Categories>()
           .HasMany<Product>()
           .WithOne(a=>a.Category).OnDelete(DeleteBehavior.SetNull);

           

            //modelBuilder.Entity<Product_Design_Images>().HasMany<ProductImages>().WithOne().OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Vendor>()
           .HasMany<Product>()
           .WithOne(a => a.Vendor).OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<ProductImages>().HasMany<Product_Design_Images>().WithOne().HasForeignKey(p => p.ProductImagesId);
           


            modelBuilder.Entity<ProductStichingType>()
           .HasMany<Product>()
           .WithOne(a => a.StichingType).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Account>()
       .HasOne<Cart>()
       .WithOne(a => a.account).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cart>()
  .HasMany<CartItem>(b=>b.cartItems)
  .WithOne().OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Account>()
       .HasOne<WishList>()
       .WithOne(a => a.account).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WishList>()
  .HasMany<WishListItem>(b=>b.WishListItems)
  .WithOne().OnDelete(DeleteBehavior.Cascade);





            modelBuilder.Entity<ProductStichingType>().HasData(new ProductStichingType { id=1, stiching_value = "Stiched" });
            modelBuilder.Entity<ProductStichingType>().HasData(new ProductStichingType { id=2, stiching_value = "UnStiched" });
            modelBuilder.Entity<ProductStichingType>().HasData(new ProductStichingType { id=3, stiching_value = "ReadyMade" });

            modelBuilder.Entity<Categories>().HasData(new Categories { id = 1, category_value = "Sarees" });
            modelBuilder.Entity<Categories>().HasData(new Categories { id = 2, category_value = "Salwar Kameez" });
            modelBuilder.Entity<Categories>().HasData(new Categories { id = 3, category_value = "Lehngas" });
            modelBuilder.Entity<Categories>().HasData(new Categories { id = 4, category_value = "Kurti" });
           

            modelBuilder.Entity<ProductFabric>().HasData(new ProductFabric { Id = 1, Value = "Cotton" });
            modelBuilder.Entity<ProductFabric>().HasData(new ProductFabric { Id = 2, Value = "Crepe" });
            modelBuilder.Entity<ProductFabric>().HasData(new ProductFabric { Id = 3, Value = "Synthatic" });
            modelBuilder.Entity<ProductFabric>().HasData(new ProductFabric { Id = 4, Value = "Georgette" });
            modelBuilder.Entity<ProductFabric>().HasData(new ProductFabric { Id = 5, Value = "Net" });
            modelBuilder.Entity<ProductFabric>().HasData(new ProductFabric { Id = 6, Value = "Chanderi" });
            modelBuilder.Entity<ProductFabric>().HasData(new ProductFabric { Id = 7, Value = "Cotton Poly" });
            modelBuilder.Entity<ProductFabric>().HasData(new ProductFabric { Id = 8, Value = "Silk" });
            modelBuilder.Entity<ProductFabric>().HasData(new ProductFabric { Id = 9, Value = "Banarasi Silk" });
            modelBuilder.Entity<ProductFabric>().HasData(new ProductFabric { Id = 10, Value = "Rayon" });
            modelBuilder.Entity<ProductFabric>().HasData(new ProductFabric { Id = 11, Value = "Modal" });
            modelBuilder.Entity<ProductFabric>().HasData(new ProductFabric { Id = 12, Value = "Pure Georgette" });
            modelBuilder.Entity<ProductFabric>().HasData(new ProductFabric { Id = 13, Value = "Pure Silk" });
            modelBuilder.Entity<ProductFabric>().HasData(new ProductFabric { Id = 14, Value = "Raw Silk" });
            modelBuilder.Entity<ProductFabric>().HasData(new ProductFabric { Id = 15, Value = "Woolen" });
            modelBuilder.Entity<ProductFabric>().HasData(new ProductFabric { Id = 16, Value = "Linen" });


            modelBuilder.Entity<ProductColor>().HasData(new ProductColor {ProductColor_ID=1, ProductColorValue = "Red"});
            modelBuilder.Entity<ProductColor>().HasData(new ProductColor { ProductColor_ID = 2, ProductColorValue = "Black" });
            modelBuilder.Entity<ProductColor>().HasData(new ProductColor { ProductColor_ID = 3, ProductColorValue = "Blue" });
            modelBuilder.Entity<ProductColor>().HasData(new ProductColor { ProductColor_ID = 4, ProductColorValue = "Green" });

            modelBuilder.Entity<ProductSize>().HasData(new ProductSize {Id = 4 ,Value = "23" });
            modelBuilder.Entity<ProductSize>().HasData(new ProductSize { Id=5, Value = "24" });
           
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, _role = UserRoles.admin });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, _role = UserRoles.endUser });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, _role = UserRoles.endUser_customer });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 4, _role = UserRoles.endUser_Reseller });

            modelBuilder.Entity<ProductTaxPercentage>().HasData(new ProductTaxPercentage { Id = 1, productstichingtypeId=1 , taxpercentage = 5, taxtype= "GST" });
            modelBuilder.Entity<ProductTaxPercentage>().HasData(new ProductTaxPercentage { Id = 2, productstichingtypeId = 2, taxpercentage = 8, taxtype = "GST" });
            modelBuilder.Entity<ProductTaxPercentage>().HasData(new ProductTaxPercentage { Id = 3, productstichingtypeId = 3, taxpercentage = 5, taxtype = "GST" });
            modelBuilder.Entity<ProductTaxPercentage>().HasData(new ProductTaxPercentage { Id = 4, productstichingtypeId = 3, taxpercentage = 12, taxtype = "GST_OverMargin" });

        }
        

        public DbSet<Account> account { get; set; }
        public DbSet<Role> role { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<ProductColor> productColor { get; set; }
        public DbSet<ProductSize> productSize { get; set; }
        public DbSet<ProductDesign> productDesign { get; set; }
        public DbSet<Categories> categories { get; set; }

        public DbSet<ProductStichingType> productstichingtype { get; set; }
        public DbSet<ProductFabric> productfabric { get; set; }
        public DbSet<Vendor> vendor { get; set; }
        public DbSet<Product_Design_Images> product_design_images { get; set; }
        public DbSet<ProductImages> productimages  { get; set; }
        public DbSet<ProductTaxPercentage> prd_tax_percentage { get; set; }
        public DbSet<Cart> cart { get; set; }
        public DbSet<CartItem> cartItems { get; set; }
        public DbSet<Cart> wishList { get; set; }
        public DbSet<CartItem> wishListItems { get; set; }


    }

    //public class ProductConfiguration : IEntityTypeConfiguration<Product>
    //{
    //    public void Configure(EntityTypeBuilder<Product> builder)
    //    {
    //        builder.ToTable("product");
            

    //        builder.HasMany(e => e.productDesign)
    //            .WithOne(s => s.product)
    //            .HasForeignKey(s => s.product)
    //            .OnDelete(DeleteBehavior.Cascade);
    //        builder.HasMany(e => e.Image_Urls)
    //          .WithOne(s => s.product)
    //          .HasForeignKey(s => s.product)
    //          .OnDelete(DeleteBehavior.Cascade);
    //    }
    //}




}
