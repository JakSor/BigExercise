using BigExercise.Logger;
using Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Repository;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigExercise.Extensions
{
    public static class ServiceExtensions
    {

        //Klasse om ConfigureServices proper te houden
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
        public static void ConfigureCustomDependencyInjection(this IServiceCollection services)
        {
            //services.AddScoped<ILogger>();


            //services.AddScoped<IConfiguration>(Configuration);
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBaseRepository<ShoppingBasket>, BaseRepository<ShoppingBasket>>();
            services.AddScoped<IBaseRepository<ShoppingBasketItem>, BaseRepository<ShoppingBasketItem>>();
        }
    }
}
