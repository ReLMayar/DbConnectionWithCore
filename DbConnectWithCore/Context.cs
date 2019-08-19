using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbConnectWithCore
{
    public class Context : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ShopCustomer> ShopCustomers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder db)
        {
            db.UseMySQL("server=localhost;UserId=root;Password=Gsnuji48i4fy4D89fp0jc3f74ound3kw _;database=testdb;");
        }
    }
}
