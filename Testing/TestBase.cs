using Data.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Repository.Interfaces;
using Repository;
using Domain;

namespace Testing
{
    public class TestBase
    {
               
        //Context aanmaken
       internal void CreateContext(out AppDbContext appDbContext)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>()
               .EnableSensitiveDataLogging()
               .UseInMemoryDatabase(Guid.NewGuid().ToString());
                
            appDbContext =new AppDbContext(builder.Options);
                       
        }
        public void PopulateContext(BaseRepository<Product> repository, out Food food)
        {
            
            food = new Food()
            {
                Id = 1,
                ExpireDate = DateTime.Now.AddYears(5),
                AmountInStock = 1000,
                IsActive = true,
                Description = "Cool food thingy",
                IsDrink = true,
                Name = "Fanta",
                Price = 12,
                QuantityInPackage = 6
            };
            repository.Insert(food);
            repository.Save();
        }

        public void CreateProductRepository(AppDbContext context, out BaseRepository<Product> repository)
        {
            repository = new BaseRepository<Product>(context);
        }
    }
}
