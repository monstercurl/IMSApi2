using IMSApi.EntityModel.Entities;
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
       
        public DbSet<Account> Account { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Product> product { get; set; }

        public DbSet<vendor> Vendor { get; set; }


    }
}
