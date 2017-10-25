﻿using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace DAL
{
    class SovaContext : DbContext
    {
        /*
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        */

        public DbSet<Post> posts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseMySql("server=192.168.1.4;database=northwind;uid=marinus;pwd=agergaard"); //martinus
            //optionsBuilder.UseMySql("server=localhost;database=northwind;uid=root;pwd=frans"); //mads
            optionsBuilder.UseMySql("server=wt-220.ruc.dk;database=stackoverflow_sample_universal;uid=raw10;pwd=raw10"); //alex
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Post>().Property(x => x.post_id).HasColumnName("post_id");
            

            /*
            //Categories
            modelBuilder.Entity<Category>().Property(x => x.Name).HasColumnName("CategoryName");
            modelBuilder.Entity<Category>().Property(x => x.Id).HasColumnName("CategoryId");

            //Products
            modelBuilder.Entity<Product>().Property(x => x.Name).HasColumnName("ProductName");
            modelBuilder.Entity<Product>().Property(x => x.Id).HasColumnName("ProductId");
            modelBuilder.Entity<Product>().Property(x => x.QuantityPerUnit).HasColumnName("QuantityUnit");

            //Order
            modelBuilder.Entity<Order>().Property(x => x.Id).HasColumnName("OrderId");
            modelBuilder.Entity<Order>().Property(x => x.Date).HasColumnName("OrderDate");
            modelBuilder.Entity<Order>().Property(x => x.Required).HasColumnName("RequiredDate");
            //modelBuilder.Entity<Order>().Property(x => x.OrderDetails).IsRequired();


            //OrderDetails
            modelBuilder.Entity<OrderDetails>().HasKey(x => new { x.OrderId, x.ProductId });
            modelBuilder.Entity<OrderDetails>()
                .HasOne(orderDetail => orderDetail.Order)
                .WithMany(order => order.OrderDetails);
            */


        }

        public List<Post> FindPostsByName(string name)
        {
            var posts = this.posts.FromSql("CALL wordSearch({0})", name).Take<Post>(10).ToList<Post>();
            Console.WriteLine(posts);

            return posts;
        }
    }
   
}