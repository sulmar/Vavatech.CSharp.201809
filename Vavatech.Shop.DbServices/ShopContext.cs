using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.DbServices
{
    public class ShopContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Item> Items { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
