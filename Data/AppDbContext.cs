using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.DataAccessLayer
{ 
    public class AppDbContext : IdentityDbContext<WebShopUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingBasket> ShoppingBaskets {get;set;}
        public DbSet<WebShopUser> WebShopUsers { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
       protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Food>();
            builder.Entity<NonFood>();
            base.OnModelCreating(builder);
        }
    }
}
