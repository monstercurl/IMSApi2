using IMSApi.EntityModel;
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
    }
}
