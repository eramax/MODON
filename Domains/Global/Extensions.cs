using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Domains;
using Newtonsoft.Json;

namespace System
{
    //public static class ExpressionExtension
    //{
    //    public static Expression<Func<TSource, bool>> ToLinQExpression<TSource, Tproperty>
    //        (this Expression<Func<TSource, Tproperty>> keySelector, Tproperty comparisonValue)
    //    {
    //        var bd = Expression.Equal(keySelector.Body, Expression.Constant(comparisonValue));
    //        return Expression.Lambda<Func<TSource, bool>>(bd, keySelector.Parameters);
    //    }
    //}

    public static class DictionaryExtension
    {
        public static void Push<TKey, T>(this Dictionary<TKey, T> dir, TKey key , T obj) 
        {
            if (dir == null || key == null) return;
            if (dir.ContainsKey(key)) dir[key] = obj;
            else dir.Add(key, obj);
        }
        public static T Pop<TKey, T>(this Dictionary<TKey, T> dir, TKey key) where T: class
        {
            if (dir == null || key == null  || !dir.ContainsKey(key)) return null;
            return dir[key];
        }
    }
    public static class LinQExtensions
    {
        public delegate void Func<in TArg0>(TArg0 element);

        public static int Update<TSource>(this IEnumerable<TSource> source, Func<TSource> update)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (update == null) throw new ArgumentNullException(nameof(update));
            if (typeof(TSource).IsValueType)
                throw new NotSupportedException("value type elements are not supported by update.");

            var count = 0;
            foreach (var element in source)
            {
                update(element);
                count++;
            }
            return count;
        }
    }

    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection == null || !collection.Any();
        }
        public static IEnumerable<TSource> Data<TSource>(this IEnumerable<TSource> source)
        {
            return source.IsNullOrEmpty() ? new List<TSource>() : source;
        }
        public static string Print(this ICollection<string> list)
        {
            return list == null ? null : string.Join(",", list);
        }
        public static List<long> GetIds<T>(this ICollection<T> list) where T : IEntityKey
        {
            var lst = new List<long>();
            if (list == null) return lst;
            lst.AddRange(list.Select(e => e.Id));
            return lst;
        }
        public static string GetNames<T>(this IEnumerable<T> list) where T : NamedBaseEntity
        {
            if (list == null) return null;
            var lst = list.Select(e => e.Name).ToList();
            return string.Join(",", lst);
        }
        public static List<Variance> CompareWith<T>(this T val1, T val2)
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic |
                                       BindingFlags.Static | BindingFlags.Instance |
                                       BindingFlags.DeclaredOnly;
            var fi = val1.GetType().GetProperties(flags);
            return fi.Select(f => new Variance { PropName = f.Name, OldVal = f.GetValue(val1), NewVal = f.GetValue(val2) }).Where(v => !v.OldVal.Equals(v.NewVal)).ToList();
        }
        public static IEnumerable<T> AsNotNull<T>(this IEnumerable<T> original)
        {
            return original ?? Enumerable.Empty<T>();
        }

        public static void Push<T>(this ICollection<T> list, T obj)
        {
            if (list.IsNotNull()) list.Add(obj);
        }
        public static void Push<T>(this ICollection<T> list, T[] objects)
        {
            if (list.IsNull()) return;
            foreach (var x in objects) list.Add(x);
        }
        public static void Push<T>(this ICollection<T> list, ICollection<T> objects)
        {
            if (list.IsNull()) return;
            foreach (var x in objects) list.Add(x);
        }
    }


    public static class ObjectExtensions
    {
        public static bool IsNotNull(this object source) => (source != null);
        public static bool IsNull(this object source) => (source == null);

        public static string ToJson(this object obj) =>
            JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

        public static long? LongValue(this object source)
        {
            if (source.IsNull()) return null;
            if (long.TryParse(source.ToString(), out var singleId))
                return singleId;
            return null;
        }
        public static bool Valid(this object source)
        {
            if (source == null) return false;
            var x = source.ToString();
            return !string.IsNullOrWhiteSpace(x);
        }


        public static TDestination To<TDestination>(this object source) => AutoMapper.Mapper.Map<TDestination>(source);
        public static TDestination To<TSource, TDestination>(this TSource source, TDestination destination)
            => AutoMapper.Mapper.Map<TSource, TDestination>(source, destination);
        public static TDestination ToDiff<TSource, TDestination>(this TSource source, TDestination destination)
            => AutoMapper.Mapper.Map<TSource, TDestination>(source, destination, opts => opts.ConfigureMap()
                   .ForAllMembers(opt => opt.Condition((src, dest, sourceMember, destMember) => (sourceMember.Valid()))));
        public static TDestination ToDiff<TDestination>(this object source, TDestination destination)
            => AutoMapper.Mapper.Map<object, TDestination>(source, destination, opts => opts.ConfigureMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, sourceMember, destMember) => (sourceMember.Valid()))));
    }
}
