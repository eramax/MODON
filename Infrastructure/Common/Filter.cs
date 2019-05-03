using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infrastructure
{
    public class Filter<TEntity> : Dictionary<string, Expression<Func<TEntity, bool>>>
    {
        public Expression<Func<TEntity, bool>> Role(string role)
        {
            return ContainsKey(role) ? this[role] : null;
        }
    }
}
