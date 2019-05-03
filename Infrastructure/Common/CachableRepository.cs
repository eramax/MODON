using Domains;
using System.Data.Entity;
using System.Linq;

namespace Infrastructure
{
    public class CachableRepository<TEntity> : Repository<TEntity> where TEntity : class, IBaseEntity
    {
        public CachableRepository(DbContext context) : base(context)
        {
            if (Entities == null)
            {
                Entities = dbSet.ToList();
            }
            dbReadSet = Entities.AsQueryable();
        }
    }
}
