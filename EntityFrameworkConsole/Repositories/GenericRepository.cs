using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EntityFrameworkConsole.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        public DB_Bands DBContext { get; set; }
        public DbSet<T> Table { get; set; }

        public GenericRepository(DB_Bands dbContext)
        {
            DBContext = dbContext;
            Table = dbContext.Set<T>();
        }

        public virtual List<T> GetAll()
        {
            return Table.ToList();
        }

        public void Add(T data)
        {   
            Table.Add(data);
        }

        public void Delete(T data)
        {
            Table.Remove(data);
        }

        public void Edit(T data)
        {
            Table.Attach(data);
            DBContext.Entry(data).State = EntityState.Modified;
        }

        public T GetById(int id)
        {
            return Table.Find(id);
        }

        public void Save()
        {
            DBContext.SaveChanges();
        }
    }
}
