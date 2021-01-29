using Ecommerce.Data.Interfaces;
using Ecommerce.Data.Models;
using Ecommerce.Data.Repositories;
using Ecommerce.Test.Factories;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Ecommerce.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task AddValidProduct_InsertsNewProduct()
        {
            // Arrange
            var factory = new ConnectionFactory();
            //Vraag context object van Factory
            var context = factory.CreateContextForSQLite();
            string prodName = "TEST PROD";


            var productRepository = new ProductRepository(context);
            var cat = new Category
            {
                Id = 1,
                Name = "TESTCATEGORY"
            };
            var product = new Product
            {
                Id = 1,
                Name = prodName,
                Category = cat
            };

            await productRepository.Add(product);
            Assert.AreEqual(1, await context.Products.CountAsync());

            var singleProd = await context.Products.SingleAsync();
            Assert.AreEqual(prodName, singleProd.Name);
        }

    }

}