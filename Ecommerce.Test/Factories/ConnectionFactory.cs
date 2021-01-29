using Ecommerce.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Test.Factories
{
    public class ConnectionFactory : IDisposable
    {

        #region IDisposable Support
        private bool disposedValue = false; 

        public ProductDbContext CreateContextForInMemory()
        {
            var option = new DbContextOptionsBuilder<ProductDbContext>().UseInMemoryDatabase(databaseName: "Test_Database").Options;

            var context = new ProductDbContext(option);
            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return context;
        }

        public ProductDbContext CreateContextForSqlServer()
        {
            var connection = new SqlConnection("Data Source=(localdb)\\mssqlLocaldb;Initial Catalog=EcommerceDbTest;Integrated Security=True;Pooling=False");
            connection.Open();

            var option = new DbContextOptionsBuilder<ProductDbContext>().UseSqlServer(connection).Options;

            var context = new ProductDbContext(option);

            return context;
        }

        public ProductDbContext CreateContextForSQLite()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var option = new DbContextOptionsBuilder<ProductDbContext>().UseSqlite(connection).Options;

            var context = new ProductDbContext(option);

            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}

