using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IBaseRepo<T>
    {
        int Insert(T entity);

        IEnumerable<T> GetAll();

        bool Delete(int id);

        int Update(T entity);
    }
}
