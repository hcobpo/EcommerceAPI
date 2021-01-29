using Ecommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Data.Interfaces
{
    public interface IProductRepositoryold// : IRepository<Product>
    {
        IEnumerable<Product> GetByCategoryName(string category);
        Product GetById(int id);
        Product Add(Product t);
        bool Update(Product t);
        bool Delete(int id);
        IEnumerable<Product> GetAll();
    }
}
