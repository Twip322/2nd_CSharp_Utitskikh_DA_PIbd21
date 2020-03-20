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
                optionsBuilder.UseSqlServer(@"Data Source=PSB133S01ZFP;Initial Catalog=DeliveryShopDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Dish> Components { set; get; }
        public virtual DbSet<Meal> Products { set; get; }
        public virtual DbSet<AddDishMeal> ProductComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }

    }
}
