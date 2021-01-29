using Ecommerce.Data.Models;
using Ecommerce.Test.Factories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ecommerce.Test
{
    class ConnectionFactoryTests
    {

        [Test]
        public void Task_Add_Without_Relation()
        {
            //Arrange  
            var factory = new ConnectionFactory();

            //Vraag context object van Factory
            var context = factory.CreateContextForInMemory();
            var cat = new Category() { Name = "Test Category", Description = "Test Cat Description" };
            var product = new Product() { Name= "Test Product", Description = "Test Description", Category=cat };

            //Act  
            var data = context.Products.Add(product);
            context.SaveChanges();

            //Assert  
            //Haal het aantal producten op
            var prodCount = context.Products.Count();
            Assert.AreEqual(1, prodCount);

            //vraag details van enkel product
            var singleProduct = context.Products.FirstOrDefault();

                Assert.AreEqual("Test Product", singleProduct.Name);

        }

        [Test]
        public void Task_Add_With_Relation()
        {
            //Arrange  
            var factory = new ConnectionFactory();

            //Vraag context object van Factory
            var context = factory.CreateContextForInMemory();

            var cat = new Category() { Name = "Test Category", Description = "Test Cat Description" };
            var product = new Product() { Name = "Test Product", Description = "Test Description", Category = cat };

            //Act  
            var data = context.Products.Add(product);
            context.SaveChanges();

            //Assert  
            //Haal het aantal producten op
            var prodCount = context.Products.Count();
            Assert.AreEqual(1, prodCount);


            //vraag details van enkel product
            var singlePost = context.Products.FirstOrDefault();
            Assert.AreEqual("Test Product", singlePost.Name);

        }

        [Test]
        public void Task_Add_Time_Test()
        {
            //Arrange  
            var factory = new ConnectionFactory();

            //Get the instance of BlogDBContext
            var context = factory.CreateContextForInMemory();

            //Act 
            var cat = new Category() { Name = "Test Category", Description = "Test Cat Description" };

            for (int i = 1; i <= 1000; i++)
            {
                var product = new Product() { Name = "Test Product " +i , Description = "Test Description " +i, Category = cat };
                context.Products.Add(product);
            }

            context.SaveChanges();

            //Assert  
            //Haal het aantal producten op
            var postCount = context.Products.Count();
            if (postCount != 0)
            {
                Assert.AreEqual(1000, postCount);
            }

            //vraag details van enkel product
            var singleProduct = context.Products.Where(x => x.Id == 1).FirstOrDefault();
            Assert.AreEqual("Test Product 1", singleProduct.Name);
        }
        //Laatste test is eigenlijk een test van de built-in Microsoft EF Core code en is niet zo nuttig om te testen
        //ofwel werkt het (meestal het geval) ofwel werkt de test niet en dan kan je er toch niets aan verhelpen
        //Beter is om op business-layer de business-rules te definiëren en deze dan te testen
        //in de datalayer moeten er dan geen attribuut-constraints worden geplaatst op de model class properties
        //zelf de code niet aanpassen
        //Deze test zal trouwens NIET werken op een Inmemory database, maar enkel met een echte Test Database
        //[Test]
        //public async Task AddInValidProduct_ThrowsException()
        //{
        //    // Arrange
        //    var factory = new ConnectionFactory();

        //    //Vraag context object van Factory
        //    var context = factory.CreateContextForSqlServer();
        //    string prodName = "TEST PROD";

        //    var cat = new Category
        //    {
        //        Id = 1,
        //        Name = "TESTCATEGORY"
        //    };
        //    var product = new Product
        //    {
        //        Id = 1,
        //        Name = prodName,
        //        UnitPrice = -1, //Ongeldige waarde
        //        Category = cat
        //    };
        //    context.Products.Add(product);

        //    //Bewaren van een product met een ongeldige property waarde moet een DbUpdateException geven           
        //    Assert.Throws<DbUpdateException>(() => context.SaveChanges());
        //    Assert.AreEqual(0, await context.Products.CountAsync());

        //}
    }
}