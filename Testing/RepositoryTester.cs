using Data.DataAccessLayer;
using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace Testing
{
    public class RepositoryTester : TestBase
    {
        [Fact]
        public void Insert_ValidData_ContextFilled()
        {
            //arrange
            CreateContext(out AppDbContext context);
            CreateProductRepository(context, out BaseRepository<Product> repository);
            //act
            PopulateContext(repository, out Food food);
            //assert
            Assert.Equal(1, context.Products.Count(p => p.Name == "Fanta"));

        }
        [Fact]
        public void Insert_InvalidData_ContextEmpty()
        {
            //arrange
            CreateContext(out AppDbContext context);
            CreateProductRepository(context, out BaseRepository<Product> repository);
            //act


        }
        [Fact]
        public void Delete_ValidData_EntityDeleted()
        {
            //arrange
            CreateContext(out AppDbContext context);
            CreateProductRepository(context, out BaseRepository<Product> repository);
            PopulateContext(repository, out Food food);
            //act
            repository.Delete(food.Id);
            repository.Save();
            Assert.Equal(0, context.Products.Count());
        }
        [Fact]
        public void Update_ValidData_EntityUpdated()
        {
            //arrange
            CreateContext(out AppDbContext context);
            CreateProductRepository(context, out BaseRepository<Product> repository);
            PopulateContext(repository, out Food food);

            //act
            food.Name = "Cola";

            repository.Update(food);
            repository.Save();

            Assert.Equal(1, context.Products.Count(p => p.Name == "Cola"));

        }

        [Theory]
        [InlineData(1)]

        //[InlineData("string")]
        public void GetTById_ValidId_TRetrieved(int id)
        {
            CreateContext(out AppDbContext context);
            CreateProductRepository(context, out BaseRepository<Product> repository);
            PopulateContext(repository, out Food food);

            var check = repository.GetTById(id);
            Assert.Equal(check, food);
        }

        [Theory]
        [InlineData(-25)]
        public void GetTById_NotExistingId_CheckIsNull(int id)
        {
            CreateContext(out AppDbContext context);
            CreateProductRepository(context, out BaseRepository<Product> repository);
            PopulateContext(repository, out Food food);

            var check = repository.GetTById(id);
            Assert.Null(check);

        }
        [Fact]
        public void GetTById_InvalidId_ExceptionThrown()
        {
            CreateContext(out AppDbContext context);
            CreateProductRepository(context, out BaseRepository<Product> repository);
            PopulateContext(repository, out Food food);

            //wilt niet compilen, hoe test ik dit?
            //var check = repository.GetTById("1");

        }
    }
}
