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
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}
