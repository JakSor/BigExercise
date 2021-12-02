
using Data.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace Testing
{
    
    public class AppDbContextTester : TestBase
    {
        [Fact]
        public void AddFoodProductInDb()
        {
            CreateContext(out AppDbContext context);
            using (context)
            {
                context.Products.Add(new Domain.Food()
                {
                    ExpireDate = DateTime.Now.AddYears(5),
                    AmountInStock = 1000,
                    IsActive = true,
                    Description = "Cool food thingy",
                    IsDrink = true,
                    Name = "Fanta",
                    Price = 12,
                    QuantityInPackage = 6

                });
                context.SaveChanges();
                Assert.Equal(1, context.Products.Count(p => p.Name == "Fanta"));
            }
        }

        [Fact]
        public void AddNonFoodProductInDb()
        {
            CreateContext(out AppDbContext context);
            using (context)
            {
                context.Products.Add(new Domain.NonFood()
                {
                    Color = "red",
                    AmountInStock = 1000,
                    IsActive = true,
                    Description = "Cool food thingy",
                    Size = "XS",
                    Name = "Fanta",
                    Price = 12,
                    

                });
                context.SaveChanges();
                Assert.Equal(1, context.Products.Count(p => p.Name == "Fanta"));
            }
        }

        [Fact]
        public void AddShoppingBasketInDb()
        {
            CreateContext(out AppDbContext context);
            using (context)
            {
                context.ShoppingBaskets.Add(new Domain.ShoppingBasket());
                
                context.SaveChanges();
                Assert.Equal(1, context.ShoppingBaskets.Count());
            }
        }

        
    }


}
