using BolFood.core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BolFood.Data
{
    public class BolFoodDbContext : DbContext
    {
        public BolFoodDbContext(DbContextOptions<BolFoodDbContext> options)
            :base(options)
        {

        }
        public DbSet<Restaurant> Restaurants{ get; set; }
    }
}
