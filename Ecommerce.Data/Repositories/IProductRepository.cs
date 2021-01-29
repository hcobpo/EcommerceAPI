using Ecommerce.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories
{
    public interface IProductRepository
    {
        Task<Product> Add(Product product);
        Task<bool> Delete(int id);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetByCategoryName(string category);
        Task<Product> GetById(int id);
        Task<bool> Update(Product product);
    }
}