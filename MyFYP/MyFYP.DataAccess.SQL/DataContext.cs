using MyFYP.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFYP.DataAccess.SQL
{
    //Adapted from -https://www.udemy.com/course/better-web-development-pro-techniques-for-success/learn/lecture/8533944?start=975#overview

 
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}

