using Ecommerce.Data.Interfaces;
using Ecommerce.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ecommerce.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;
        public ProductRepository()
        {
            _dbContext = new ProductDbContext();
        }
        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product> GetById(int id)
        {
            return await _dbContext.Products.Include(p => p.Category).Where(p => p.Id == id).SingleOrDefaultAsync();
        }
        public async Task<Product> Add(Product product)
        {
            var result = await _dbContext.Products.AddAsync(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public async Task<bool> Update(Product product)
        {
            var result = _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return result.State == EntityState.Modified;
        }
        public async Task<bool> Delete(int id)
        {
            var product = GetById(id);
            if (product == null)
                throw new InvalidOperationException("Product Does not Exist!");
            var result = _dbContext.Products.Remove(product.Result);
            _dbContext.SaveChanges();
            return result.State == EntityState.Deleted;
        }
        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products.Include(p => p.Category).ToList();
        }
        public IEnumerable<Product> GetByCategoryName(string category)
        {
            return _dbContext.Products.Include(p => p.Category).Where(p => p.Category.Name == category);
        }


    }

}
