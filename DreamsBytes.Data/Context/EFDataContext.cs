using DreamsBytes.Core.Entites;
using DreamsBytes.Data.Mappings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace DreamsBytes.Data.Context
{
    public class AppSettings
    {
        public bool ShouldRefreshDb { get; set; }
    }
    public class EFDataContext : DbContext
    {

        public EFDataContext()
       
        {
           
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<UserPassword> UserPasswords { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UserPasswordMap());
            modelBuilder.ApplyConfiguration(new ShoppingCartItemMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderItemMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductTypeMap());
         
              base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {           
            var jsonBytes = File.ReadAllBytes("appsettings.json");
            using var jsonDoc = JsonDocument.Parse(jsonBytes);
            var root = jsonDoc.RootElement;
            var myString = root.GetProperty("ConnectionStrings").GetProperty("DefaultConnection").GetString();
            optionsBuilder.UseSqlServer(myString);
            
        }
    }

}
