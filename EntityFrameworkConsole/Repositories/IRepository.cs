using System.Collections.Generic;

namespace EntityFrameworkConsole.Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T data);
        void Edit(T data);
        void Delete(T data);
        void Save();
    }
}
