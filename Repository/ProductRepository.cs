using Data.DataAccessLayer;
using Domain;
using Domain.Parameters;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Product>> GetProducts(ProductParameters parameters)
        {
            var products = GetTs();
            if (parameters.InStock == true)
            {
                products.Select(product => product.AmountInStock > 0);
            }
            return await Task.Run(() => products.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                  .Take(parameters.PageSize)
                  .ToList());
            }
    }
}
