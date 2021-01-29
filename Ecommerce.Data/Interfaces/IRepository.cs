using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Data.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(int id);
        T Add(T t);
        bool Update(T t);
        bool Delete(int id);
        IEnumerable<T> GetAll();
    }
}
