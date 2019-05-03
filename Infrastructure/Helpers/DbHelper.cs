using Domains;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infrastructure
{
    public class DbHelper
    {
        public static List<T> ManyToMany<TEntity, T>(UnitWork uw, IEntityKey vm, Expression<Func<TEntity, object>> include, List<long> ids, ref IMDResponse res)
            where TEntity : class, IBaseEntity
            where T : class, IBaseEntity
        {
            var x = new List<T>();
            Func<TEntity, object> func = include.Compile();
            var ent = uw.QueryEntity<TEntity>().GetByID(vm.Id, false, include);
            if (ent != null && func(ent) != null) { (func(ent) as ICollection<T>).Clear(); uw.Command<TEntity>().Update(ent, ref res); }
            if (ids != null) x.AddRange(uw.QueryEntity<T>().GetByIDs(ids.ToArray()));
            return x;
        }
        public static void OneToMany<TEntityMany>(UnitWork uw, Action<TEntityMany> action, ref IMDResponse res, params TEntityMany[] items)
            where TEntityMany : class, IBaseEntity, new()
        {
            foreach (var it in items) {
                action(it);
                uw.Command<TEntityMany>().AddOrUpdate(it, ref res);
            }
        }
    }
}
