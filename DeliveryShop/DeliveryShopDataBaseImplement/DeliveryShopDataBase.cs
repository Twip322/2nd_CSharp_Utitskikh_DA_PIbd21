using DeliveryShopDataBaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryShopDataBaseImplement
{
    public class DeliveryShopDataBase:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-1KN7FL1;Initial Catalog=DeliveryShopDatabase1;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Dish> Components { set; get; }
        public virtual DbSet<Meal> Products { set; get; }
        public virtual DbSet<AddDishMeal> ProductComponents { set; get; }
        public virtual DbSet<Implementer> Implementers { get; set; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Client> Clients { set; get; }

    }
}
