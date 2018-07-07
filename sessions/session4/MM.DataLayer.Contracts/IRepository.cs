using System.Collections.Generic;

namespace MM.DataLayer.Contracts
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll(int skip = 0, int take = 100);
        T GetById(int id);
        T Create(T album);
        T Update(T album);
        bool Delete(T album);
    }
}
